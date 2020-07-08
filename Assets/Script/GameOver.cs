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
    }
    public void NextLevel()
    {
        Player_Management.Instance.ahp = 50;
        Player_Management.Instance.position = new Vector3 (0,0,0);
        Player_Management.Instance.save_point = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
