using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Debug.Log("nigga");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
