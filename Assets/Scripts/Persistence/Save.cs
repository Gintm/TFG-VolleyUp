using System.Collections.Generic;
using System.IO;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    internal static class SaveToJson
    {
        private const string PlayerFileName = "PlayerData.json";
        private const string ExercisesFileName = "ExercisesData.json";

        public static void PlayerData( ScriptableObject gameData )
        {
            string path = Path.Combine( Application.persistentDataPath, PlayerFileName );
            string json = JsonUtility.ToJson( gameData, true );
            File.WriteAllText( path, json );
            Debug.Log( "PlayerData saved to: " + path );
        }

        public static void ExerciseData( List<string> data )
        {
            string path = Path.Combine( Application.persistentDataPath, ExercisesFileName );
            ExerciseModel exerciseList = new ExerciseModel { exercises = data };
            string json = JsonUtility.ToJson( exerciseList, true );
            File.WriteAllText( path, json );
            Debug.Log( "ExercisesData saved to: " + path );
        }
    }
}