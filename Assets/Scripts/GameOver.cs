using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using Persistence;

public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text coinsText;

    GameObject retryButton;
    
    [SerializeField] PlayerDataController playerDataController;

    public void UpdateView(ResultOfTheRound result)
    {
        var roundDuration = (float)result.Duration.TotalSeconds;
        scoreText.text = result.HitsProportion.ToPercentage();
        timeText.text = TimeFormat.AsStopwatch(roundDuration);
        coinsText.text = result.Coins.ToString();


        if(result.HasLost)
            Lose();

        playerDataController.Save();
    }

    public void Retry()
    {
        Utils.ChangeScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void GoToMainMenu()
    {
        int mainMenuIndexScene = 1;
        Utils.ChangeScene( mainMenuIndexScene );
    }

    public void Lose()
    {
        GameObject gameOverPanel = GameObject.Find( "GameOverPanel" );
        retryButton = gameOverPanel.transform.Find( "Retry" ).gameObject;
        Assert.IsNotNull( retryButton );
        retryButton.SetActive( true );
    }
}