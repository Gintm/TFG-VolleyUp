using System.IO;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    internal static class LoadFromJson
    {
        const string PlayerFileName = "PlayerData.json";
        const string ExercisesFileName = "ExercisesData.json";

        public static PlayerData PlayerData()
        {
            string path = Path.Combine( Application.persistentDataPath, PlayerFileName );
            if( File.Exists( path ) )
            {
                string jsonData = File.ReadAllText( path );
                Debug.Log( "Loaded PlayerData from: " + path );
                return JsonUtility.FromJson<PlayerData>( jsonData );
            }

            TextAsset defaultJson = Resources.Load<TextAsset>( "DB/PlayerData" );
            if( defaultJson != null )
            {
                File.WriteAllText( path, defaultJson.text );
                Debug.Log( "Initialized PlayerData from Resources and saved to: " + path );
                return JsonUtility.FromJson<PlayerData>( defaultJson.text );
            }

            Debug.LogError( "PlayerData JSON not found in persistent path or Resources." );
            return null;
        }

        public static Round OneRound(string textToLoad, int sessionToLoad, int levelToLoad)
        {
            var data = JsonUtility.FromJson<QuestionModel>( textToLoad );
            Level currentLevel = data.sessions[sessionToLoad].levels[levelToLoad];
            return new Round( currentLevel );
        }

        public static ExerciseModel ExercisesData()
        {
            string path = Path.Combine( Application.persistentDataPath, ExercisesFileName );

            if( File.Exists( path ) )
            {
                string jsonData = File.ReadAllText( path );
                Debug.Log( "Loaded ExercisesData from: " + path );
                return JsonUtility.FromJson<ExerciseModel>( jsonData );
            }

            TextAsset defaultJson = Resources.Load<TextAsset>( "DB/ExercisesData" );
            if( defaultJson != null )
            {
                File.WriteAllText( path, defaultJson.text );
                Debug.Log( "Initialized ExercisesData from Resources and saved to: " + path );
                return JsonUtility.FromJson<ExerciseModel>( defaultJson.text );
            }

            Debug.LogError( "ExercisesData JSON not found in persistent path or Resources." );
            return null;
        }
    }
}