using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExerciseModel
{
    public List<string> exercises;

    public bool HasExercises => exercises.Count > 0;
}
