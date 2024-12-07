using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    public class GameOverScreen : MonoBehaviour
    {
        //Attributes


        //Method
        public void StartGameOver()
        {
            gameObject.SetActive(true);
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        }
    }
}
