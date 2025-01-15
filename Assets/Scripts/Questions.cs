using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Questions
{
    List<Question> questions;
    
    public int HowMany => questions.Count;
    
    /// <remarks> No CQS </remarks>
    public Question PickRandom()
    {
        var picked = PickOneCQS();
        questions.Remove( picked );
        return picked;
    }

    Question PickOneCQS()
    {
        var picked = questions[Random.Range( 0, questions.Count )];
        return picked;
    }
}