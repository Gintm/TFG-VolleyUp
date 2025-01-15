using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text scoreText;

    GameObject retryButton;
    
    //[SerializeField] PlayerDataController playerDataController;

    public void UpdateView(ResultOfTheRound result)
    {
        var roundDuration = (float)result.Duration.TotalSeconds;
        scoreText.text = result.HitsProportion.ToString();
        timeText.text = TimeFormat.AsStopwatch(roundDuration);

        if(result.HasLost)
            Lose();
    }

    private void ChangeScene( int index )
    {
        //playerDataController.SendMessage( "SaveToJson" );
        SceneManager.LoadScene( index );
    }

    public void Retry()
    {
        ChangeScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void GoToMainMenu()
    {
        int mainMenuIndexScene = 1;
        ChangeScene( mainMenuIndexScene );
    }

    public void Lose()
    {
        GameObject gameOverPanel = GameObject.Find( "GameOverPanel" );
        retryButton = gameOverPanel.transform.Find( "Retry" ).gameObject;
        Assert.IsNotNull( retryButton );
        retryButton.SetActive( true );
    }
}