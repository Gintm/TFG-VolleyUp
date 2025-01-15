using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Presentation;

public class CarouselManager : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject gameData;
    public event EventHandler OnCurrentSessionLoaded;

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
            InvokeRepeating( "AutoMoveContent", 1f, 1f ); // Invoke every second to update the timer
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
        dot.GetComponent<NavigationDot>().Init(isCurrent);
    }

    void UpdateDots()
    {
        // Update the appearance of dots based on the current index
        for( int i = 0; i < dotsContainer.transform.childCount; i++ )
        {
            Image dotImage = dotsContainer.transform.GetChild( i ).GetComponent<Image>();
            dotImage.color = ( i == currentIndex ) ? Color.white : Color.gray;

            float targetFillAmount = timer / autoMoveTime;
            StartCoroutine( SmoothFill( dotImage, targetFillAmount, 0.5f ) );
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

        image.fillAmount = targetFillAmount; // Ensure it reaches the exact target
    }

    void Update()
    {
        // Detect swipe input only within the content area
        DetectSwipe();
        //TODO: WHEN NOTIFIED
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

            // Check if the swipe is within the content area bounds
            if( Mathf.Abs( swipeDistance ) > swipeThreshold && IsTouchInContentArea( touchStartPos ) )
            {
                if( isLimitedSwipe && ( ( currentIndex == 0 && swipeDistance > 0 ) || ( currentIndex == contentPanels.Count - 1 && swipeDistance < 0 ) ) )
                {
                    // Limited swipe is enabled, and at the edge of content
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
        timer -= 1f; // Decrease timer every second

        if( timer <= 0 )
        {
            timer = autoMoveTime;
            NextContent();
        }

        UpdateDots(); // Update dots on every timer tick
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

            // Update dot visibility and color based on the current active content
            Image dotImage = dotsContainer.transform.GetChild( i ).GetComponent<Image>();
            dotImage.color = isActive ? Color.white : Color.gray;

            if( isActive )
            {
                // Reset timer and fill amount when the content is swiped
                timer = autoMoveTime;
                dotImage.fillAmount = 1f;
            }
            else
            {
                // Set the fill amount to 0 for non-active content
                dotImage.fillAmount = 0f;
            }
        }
    }
}