using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] TMP_Text TimeText;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject retryButton;
    
    [SerializeField] PlayerDataController playerDataController;

    public void UpdateView(ResultOfTheRound result)
    {
        var roundDuration = (float)result.Duration.TotalSeconds;
        ScoreText.text = result.HitsProportion.ToString();
        TimeText.text = TimeFormat.AsStopwatch(roundDuration);

        if(result.HasLost)
            Lose();
    }
    
    public void Retry()
    {
        ChangeScene( SceneManager.GetActiveScene().buildIndex );
    }
    
    private void ChangeScene( int index )
    {
        playerDataController.SendMessage( "SaveToJson" );
        SceneManager.LoadScene( index );
    }
    
    public void GoToMainMenu()
    {
        int mainMenuIndexScene = 1;
        ChangeScene( mainMenuIndexScene );
    }

    public void Lose()
    {
        retryButton = GameOverPanel.transform.Find("Retry").gameObject;
        Assert.IsNotNull( retryButton );
        retryButton.SetActive( true );
    }
}