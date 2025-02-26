using System.IO;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Persistence
{
    internal static class Utils
    {
        public static void ChangeScene( int sceneIndex )
        {
            SceneManager.LoadScene( sceneIndex );
        }
    }
}
