using System.IO;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    internal static class LoadFromJson
    {
        const string Path = "Assets//DB//PlayerData.txt";
    
        public static PlayerData PlayerData()
        {
            var jsonData = File.ReadAllText(Path);
            return JsonUtility.FromJson<PlayerData>( jsonData );
        }

        public static Round OneRound(string textToLoad, int sessionToLoad, int levelToLoad)
        {
            var data = JsonUtility.FromJson<QuestionModel>( textToLoad );
            Level currentLevel = data.sessions[sessionToLoad].levels[levelToLoad];
            return new Round( currentLevel );
        }
    }
}