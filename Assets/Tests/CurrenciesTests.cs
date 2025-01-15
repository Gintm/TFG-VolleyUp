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
        public IEnumerator StrikesAreOne()
        {
            SceneManager.LoadScene("MainMenu");
            yield return new WaitForSeconds(1);
            
            var strikes = GameObject.Find("Strike").GetComponentInChildren<TMP_Text>().text;
            
            Assert.AreEqual("1", strikes);
        }

        [UnityTest]
        public IEnumerator CoinsAre200()
        {
            SceneManager.LoadScene("MainMenu");
            yield return new WaitForSeconds(1);
            
            var coins = GameObject.Find("Coins").GetComponentInChildren<TMP_Text>().text;
            
            Assert.AreEqual("200", coins);
        }
        
        [UnityTest]
        public IEnumerator LifesAreZero()
        {
            SceneManager.LoadScene("MainMenu");
            yield return new WaitForSeconds(1);
            
            var balls = GameObject.Find("Lifes").GetComponentInChildren<TMP_Text>().text;
            
            Assert.AreEqual("0", balls);
        }
    }
}