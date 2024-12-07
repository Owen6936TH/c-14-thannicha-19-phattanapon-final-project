using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScreen : MonoBehaviour
{
    //Attributes


    //Method
    public void WinScreen()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
