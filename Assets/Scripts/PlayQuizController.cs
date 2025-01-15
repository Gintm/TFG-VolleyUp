using System;
using DefaultNamespace;
using Persistence;
using TMPro;
using UnityEngine;

public class PlayQuizController : MonoBehaviour
{
    [SerializeField] GameOver gameOverController;
    
    Round round;
    RoundRepo roundRepo;
    PlayerRepo playerRepo;

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
        quizOrGameOverPanels.Toggle();
        playerRepo.SaveOneRound(round);
        
        gameOverController.UpdateView(round.SealResult());
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
        round = roundRepo.OneRound();
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
        GetComponent<QuestionView>().SetupData(question);
    }
}
