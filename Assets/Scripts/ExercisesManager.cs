using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Persistence;

public class ExercisesManager : MonoBehaviour
{
    public TMP_InputField exerciseInputField;
    public Button addButton;
    public Transform exerciseListContainer;
    public GameObject exercisePrefab;

    private List<string> exercises = new List<string>();

    void Start()
    {
        ExerciseModel exerciseModel = LoadFromJson.ExercisesData();
        if ( exerciseModel.HasExercises)
        {
            foreach (var exercise in exerciseModel.exercises )
            {
                exerciseInputField.text = exercise;
                AddExercise();
            }
        }
        addButton.onClick.AddListener( AddExercise );
    }

    public void AddExercise()
    {
        string exerciseText = exerciseInputField.text;
        if( !string.IsNullOrEmpty( exerciseText ) )
        {
            exercises.Add( exerciseText );
            GameObject newExercise = Instantiate( exercisePrefab );
            newExercise.transform.SetParent( exerciseListContainer, false );
            newExercise.GetComponentInChildren<TMP_Text>().text = exerciseText;
            newExercise.GetComponentInChildren<Button>().onClick.AddListener( () => RemoveExercise( newExercise, exerciseText ) );
            exerciseInputField.text = "";
        }
    }

    public void RemoveExercise( GameObject exerciseObject, string exerciseText )
    {
        exercises.Remove( exerciseText );
        Destroy( exerciseObject );
    }

    public void GoToHome()
    {
        SaveToJson.ExerciseData( exercises );
        int homeIndexScene = 1;
        Utils.ChangeScene( homeIndexScene );
    }
}