using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Presentation;

public class CarouselManager : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject gameData;

    [Header( "Content Viewport" )]
    public List<GameObject> contentPanels;

    [Header( "Navigation Dots" )]
    public GameObject dotsContainer;
    public GameObject dotPrefab;

    [Header( "Page Settings" )]
    public bool isLimitedSwipe = false;
    public int currentIndex = 0;
    public float swipeThreshold = 50f;
    private Vector2 touchStartPos;

    private int currentSession, currentLevel = 0;

    public RectTransform contentArea;

    void Start()
    {
        currentSession = gameData.GetCurrentSession();
        currentLevel = gameData.GetCurrentLevel();
        currentIndex = currentLevel == 2 ? currentSession + 1 : currentSession;

        DisabledUnlockedButtons();

        CreateOneDotPerPanel();

        ShowContent();
    }

    void DisabledUnlockedButtons()
    {
        bool disable = false;

        for( int panel_index = 0; panel_index < contentPanels.Count; panel_index++ )
        {
            Transform panel = contentPanels[panel_index].transform;
            for( int button_index = 0; button_index < panel.childCount - 1; button_index++ )
            {
                Button button = panel.GetChild( button_index ).GetComponent<Button>();
                if( button != null )
                {
                    if( disable )
                    {
                        button.interactable = false;
                    }

                    bool isNextButton = panel_index == currentSession && button_index == currentLevel + 1;
                    if( isNextButton || panel_index > currentSession )
                    {
                        disable = true;
                    }
                }
            }
        }
    }

    void CreateOneDotPerPanel()
    {
        for( var i = 0; i < contentPanels.Count; i++ )
            CreateDot( i == currentIndex );
    }

    void CreateDot(bool isCurrent)
    {
        var dot = Instantiate( dotPrefab, dotsContainer.transform );
        dot.GetComponentInChildren<NavigationDot>().UpdateColor( isCurrent );
    }

    void UpdateDots()
    {
        for( int i = 0; i < dotsContainer.transform.childCount; i++ )
        {
            var dot = dotsContainer.transform.GetChild( i );
            dot.GetComponentInChildren<NavigationDot>().UpdateColor( i == currentIndex );
        }
    }

    void Update()
    {
        DetectSwipe();
        int gameDataCurrentSession = gameData.GetCurrentSession();
        if( gameDataCurrentSession != currentSession )
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