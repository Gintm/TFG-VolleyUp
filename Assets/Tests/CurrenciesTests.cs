using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class CurrenciesTests
    {
        [UnityTest]
        public IEnumerator StreaksAreZero()
        {
            SceneManager.LoadScene("Home");
            yield return new WaitForSeconds(1);
            
            var streaks = GameObject.Find("Streaks").GetComponentInChildren<TMP_Text>().text;
            
            Assert.AreEqual("0", streaks );
        }

        [UnityTest]
        public IEnumerator CoinsAre1080()
        {
            SceneManager.LoadScene("Home");
            yield return new WaitForSeconds(1);
            
            var coins = GameObject.Find("Coins").GetComponentInChildren<TMP_Text>().text;
            
            Assert.AreEqual("1080", coins);
        }
        
        [UnityTest]
        public IEnumerator LifesAreNotZero()
        {
            SceneManager.LoadScene("Home");
            yield return new WaitForSeconds(1);
            
            var lifes = GameObject.Find("Lifes").GetComponentInChildren<TMP_Text>().text;
            
            Assert.AreNotEqual("0", lifes);
        }
    }
}