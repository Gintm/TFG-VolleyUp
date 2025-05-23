using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class SmokeTests
    {
        [UnityTest]
        public IEnumerator Home_Works()
        {
            SceneManager.LoadScene("Home");
            yield return null;
        }


        [UnityTest]
        public IEnumerator DotsAreLoaded_OnePerCategoryOfQuestions()
        {
            SceneManager.LoadScene("Home");
            yield return new WaitForSeconds(1);

            var dots = GameObject.Find("DotContainer").transform.childCount;
            
            Assert.AreEqual(dots, 7);
        }
    }
}