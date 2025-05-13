using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    PlayerDataController playerDataController;

    void Start()
        => playerDataController = GameObject.FindGameObjectWithTag( "Header" ).GetComponent<PlayerDataController>();

    public void ChangeScene( string scene ) => SceneManager.LoadScene( scene );

    public void PlayTest( string scene )
    {
        if( playerDataController.HasNoLifes() )
            return;

        CarouselManager carousel = FindObjectOfType<CarouselManager>();
        PlayerInGameStats.SaveSession( carousel.CurrentSession() );
        ChangeScene( scene );
    }
}
