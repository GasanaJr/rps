using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneManagerScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPlayerVsPlayer()
    {
        SceneManager.LoadScene(3);
    }


}
