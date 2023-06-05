using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panel;

    public void ResumeGame()
    {
        panel.SetActive(false);    
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(false);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
