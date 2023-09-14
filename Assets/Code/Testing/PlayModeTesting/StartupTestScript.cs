using System.Collections;
using Endciv;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class StartupTestScript
    {

        [OneTimeSetUp]
        public void LoadInitialScene()
        {
            SceneManager.LoadScene(0);
        }

        [Test, Order(1)]
        public void LoadMainScene()
        {
            Debug.Log("Loading main scene");
        }

        [UnityTest, Order(2)]
        public IEnumerator WaitForMainMenu()
        {
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "MainMenu");
        }

        [Test, Order(3)]
        public void StartNewGame()
        {
            GameObject menuObject = GameObject.FindGameObjectWithTag("MainCanvas");
            Assert.IsNotNull(menuObject);
            ScenarioController scenario = menuObject.GetComponentInChildren<ScenarioController>(true);
            Assert.IsNotNull(scenario);
            scenario.OnStartGame();
        }

        [UnityTest, Order(4)]
        public IEnumerator WaitForIngame()
        {
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Game");
        }

        [UnityTest, Order(5)]
        public IEnumerator RunIngame()
        {
            yield return new WaitForSeconds(5);
        }
    }
}
