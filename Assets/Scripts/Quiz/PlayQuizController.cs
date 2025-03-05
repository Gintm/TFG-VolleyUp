using System;
using DefaultNamespace;
using UnityEngine;

public class PlayQuizController : MonoBehaviour
{
    Round round;
    RoundRepo roundRepo;
    PlayerRepo playerRepo;

    GameOver gameOver;
    ToggleGameObjects quizOrGameOverPanels;

    public void Answered( bool isCorrect )
    {
        if( isCorrect )
            round.Hit();
        else
            round.Wrong();

        generateQuestion();
    }
    
    void ToGameOver()
    {
        if (!round.HasLost)
        {
            round.EarnCoins();
        }

        quizOrGameOverPanels.Toggle();
        playerRepo.SaveOneRound(round);

        gameOver.UpdateView(round.SealResult());
    }

    public void Inject(RoundRepo repo, PlayerRepo playerRepo)
    {
        this.roundRepo = repo;
        this.playerRepo = playerRepo;
    }

    private void Start()
    {
        setUpData();
        generateQuestion();
    }

    private void setUpData()
    {
        int session = PlayerPrefs.GetInt( "Session", 0 );
        int level = PlayerPrefs.GetInt( "Level", 0 );
        round = roundRepo.OneRound(session, level);
        quizOrGameOverPanels = new ToggleGameObjects( GameObject.Find( "QuizUI" ), GameObject.Find( "GameOverPanel" ) );
        gameOver = GetComponent<GameOver>();
    }

    private void generateQuestion()
    {
        if (round.HasEnded)
            ToGameOver();
        else
            NextQuestion();
    }

    private void Update()
    {
        round?.PassTime(TimeSpan.FromSeconds(Time.deltaTime));
    }

    void NextQuestion()
    {
        var question = round.PickNextQuestion();
        FindObjectOfType<QuestionView>().SetupData(question);
    }
}
