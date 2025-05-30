﻿using TMPro;
using UnityEngine;

public class QuestionView : MonoBehaviour
{
    [SerializeField] GameObject[] Buttons;
    [SerializeField] TMP_Text QuestionText;
    
    public void SetupData(Question model)
    {
        QuestionText.text = model.title;
        
        for ( int i = 0; i < Buttons.Length; i++ )
        {
            Buttons[i].GetComponent<AnswerScript>().isCorrect = false;

            if( Buttons[i].transform.childCount > 0 )
            {
                Transform child = Buttons[i].transform.GetChild( 0 );
                child.GetComponent<TMP_Text>().text = model.answers[i];
            }

            if( model.correctAnswer == i + 1 )
            {
                Buttons[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
}