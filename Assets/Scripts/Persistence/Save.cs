using System.IO;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    internal static class SaveToJson
    {
        const string Path = "Assets//DB//PlayerData.txt";

        public static void PlayerData( ScriptableObject gameData )
        {
            string json = JsonUtility.ToJson( gameData, true );
            File.WriteAllText( Path, json );
        }
    }
}