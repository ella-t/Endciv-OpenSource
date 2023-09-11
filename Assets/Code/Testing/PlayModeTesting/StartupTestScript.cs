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

        // A Test behaves as an ordinary method
        [Test, Order(1)]
        public void LoadMainScene()
        {
            Debug.Log("Loading main scene");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest, Order(2)]
        public IEnumerator WaitForMainMenu()
        {
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "MainMenu");
        }

        [Test, Order(3)]
        public void StartNewGame()
        {
            GameObject menuObject = GameObject.FindGameObjectWithTag("MainMenu");
            ScenarioController scenario = menuObject.GetComponentInChildren<ScenarioController>(true);
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
