using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    internal static class SaveToJson
    {
        const string Path = "Assets//DB//PlayerData.txt";
        const string ExercisesPath = "Assets/DB/ExercisesData.json";

        public static void PlayerData( ScriptableObject gameData )
        {
            string json = JsonUtility.ToJson( gameData, true );
            File.WriteAllText( Path, json );
        }

        public static void ExerciseData( List<string> data )
        {
            ExerciseModel exerciseList = new ExerciseModel { exercises = data };
            string json = JsonUtility.ToJson( exerciseList, true );
            File.WriteAllText( ExercisesPath, json );
        }
    }
}