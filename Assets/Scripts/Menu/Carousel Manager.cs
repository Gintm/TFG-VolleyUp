using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Presentation;
using static Codice.CM.Common.CmCallContext;

public class CarouselManager : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject gameData;

    [Header( "Content Vieport" )]
    public Image contentDisplay;
    public List<GameObject> contentPanels;

    [Header( "Navigation Dots" )]
    public GameObject dotsContainer;
    public GameObject dotPrefab;

    [Header( "Page Settings" )]
    public bool useTimer = false;
    public bool isLimitedSwipe = false;
    public float autoMoveTime = 5f;
    private float timer;
    public int currentIndex = 0;
    public float swipeThreshold = 50f;
    private Vector2 touchStartPos;

    private int currentSession = 0;

    public RectTransform contentArea;

    void Start()
    {
        currentSession = gameData.GetCurrentSession();
        currentIndex = currentSession;

        CreateOneDotPerPanel();

        ShowContent();

        if( useTimer )
        {
            timer = autoMoveTime;
            InvokeRepeating( "AutoMoveContent", 1f, 1f );
        }
    }

    void CreateOneDotPerPanel()
    {
        for(var i = 0; i < contentPanels.Count; i++ )
            CreateDot(i == currentIndex);
    }

    void CreateDot(bool isCurrent)
    {
        var dot = Instantiate( dotPrefab, dotsContainer.transform );
        dot.GetComponentInChildren<NavigationDot>().UpdateColor( isCurrent);
    }

    void UpdateDots()
    {
        for( int i = 0; i < dotsContainer.transform.childCount; i++ )
        {
            var dot = dotsContainer.transform.GetChild( i );
            dot.GetComponentInChildren<NavigationDot>().UpdateColor( i == currentIndex );
        }
    }

    IEnumerator SmoothFill( Image image, float targetFillAmount, float duration )
    {
        float startFillAmount = image.fillAmount;
        float elapsedTime = 0f;

        while( elapsedTime < duration )
        {
            image.fillAmount = Mathf.Lerp( startFillAmount, targetFillAmount, elapsedTime / duration );
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.fillAmount = targetFillAmount;
    }

    void Update()
    {
        DetectSwipe();
        int gameDataCurrentSession = gameData.GetCurrentSession();
        if ( gameDataCurrentSession != currentSession )
        {
            currentSession = gameDataCurrentSession;
            currentIndex = currentSession;
            ShowContent();
        }
    }

    void DetectSwipe()
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            touchStartPos = Input.mousePosition;
        }

        if( Input.GetMouseButtonUp( 0 ) )
        {
            Vector2 touchEndPos = Input.mousePosition;
            float swipeDistance = touchEndPos.x - touchStartPos.x;

            if( Mathf.Abs( swipeDistance ) > swipeThreshold && IsTouchInContentArea( touchStartPos ) )
            {
                if( isLimitedSwipe && ( ( currentIndex == 0 && swipeDistance > 0 ) || ( currentIndex == contentPanels.Count - 1 && swipeDistance < 0 ) ) )
                {
                    return;
                }

                if( swipeDistance > 0 )
                {
                    PreviousContent();
                }
                else
                {
                    NextContent();
                }
            }
        }
    }

    bool IsTouchInContentArea( Vector2 touchPosition )
    {
        return RectTransformUtility.RectangleContainsScreenPoint( contentArea, touchPosition );
    }

    void AutoMoveContent()
    {
        timer -= 1f;

        if( timer <= 0 )
        {
            timer = autoMoveTime;
            NextContent();
        }

        UpdateDots();
    }

    void NextContent()
    {
        currentIndex = ( currentIndex + 1 ) % contentPanels.Count;
        ShowContent();
        UpdateDots();
    }

    void PreviousContent()
    {
        currentIndex = ( currentIndex - 1 + contentPanels.Count ) % contentPanels.Count;
        ShowContent();
        UpdateDots();
    }

    void ShowContent()
    {
        for( int i = 0; i < contentPanels.Count; i++ )
        {
            bool isActive = i == currentIndex;
            contentPanels[i].SetActive( isActive );

            Image dotImage = dotsContainer.transform.GetChild( i ).GetComponent<Image>();
            dotImage.color = isActive ? Color.white : Color.gray;

            if( isActive )
            {
                timer = autoMoveTime;
                dotImage.fillAmount = 1f;
            }
            else
            {
                dotImage.fillAmount = 0f;
            }
        }
    }

    public int CurrentSession()
    {
        return currentIndex;
    }
}