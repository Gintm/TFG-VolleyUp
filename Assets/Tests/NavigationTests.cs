using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class NavigationTests
    {
        [UnityTest]
        public IEnumerator PlayButton_LoadHomeScene()
        {
            SceneManager.LoadScene("MainMenu");
            yield return new WaitForSeconds(1);
            
            Object.FindObjectsOfType<Button>().First(b => b.name == "PlayButton").onClick.Invoke();
            yield return null;
            
            Assert.AreEqual("Home", SceneManager.GetActiveScene().name);
        }
    }
}