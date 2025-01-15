using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public PlayQuizController manager;

    public void Answer()
    {
        if( isCorrect )
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }

        manager.Answered( isCorrect );
    }
}
