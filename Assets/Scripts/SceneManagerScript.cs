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
        SceneManager.LoadScene(1);
    }


}
