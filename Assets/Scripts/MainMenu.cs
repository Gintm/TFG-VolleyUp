using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    PlayerDataController playerDataController;
    int currentSession = 0;

    void Start()
        => playerDataController = GameObject.FindGameObjectWithTag( "Header" ).GetComponent<PlayerDataController>();

    public void ChangeScene( string scene ) => SceneManager.LoadScene( scene );

    public void PlayTest( string scene )
    {
        if( playerDataController.HasNoLifes() )
            return;
        
        ChangeScene( scene );
    }
}
