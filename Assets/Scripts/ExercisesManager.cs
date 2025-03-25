using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Persistence;

public class TaskManager : MonoBehaviour
{
    public TMP_InputField taskInputField;
    public Button addButton;
    public Transform taskListContainer;
    public GameObject taskPrefab;

    private List<string> tasks = new List<string>();

    void Start()
    {
        ExerciseModel exerciseModel = LoadFromJson.ExercisesData();
        if ( exerciseModel.HasExercises)
        {
            foreach (var exercise in exerciseModel.exercises )
            {
                taskInputField.text = exercise;
                AddTask();
            }
        }
        addButton.onClick.AddListener( AddTask );
    }

    public void AddTask()
    {
        string taskText = taskInputField.text;
        if( !string.IsNullOrEmpty( taskText ) )
        {
            tasks.Add( taskText );
            GameObject newTask = Instantiate( taskPrefab );
            newTask.transform.SetParent( taskListContainer, false );
            newTask.GetComponentInChildren<TMP_Text>().text = taskText;
            newTask.GetComponentInChildren<Button>().onClick.AddListener( () => RemoveTask( newTask, taskText ) );
            taskInputField.text = "";
        }
    }

    public void RemoveTask( GameObject taskObject, string taskText )
    {
        tasks.Remove( taskText );
        Destroy( taskObject );
    }

    public void GoToMainMenu()
    {
        SaveToJson.ExerciseData( tasks );
        int mainMenuIndexScene = 1;
        Utils.ChangeScene( mainMenuIndexScene );
    }
}