using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public SceneManagerScript sceneManager;
    public GameLogic gameLogic = new();

    private bool canPlay = true;

    private void Start()
    {
        canPlay = true;
        uiManager.InitializeUI();
    }

    public void SetPlayerChoice(string choice)
    {
        if (!canPlay) return;
        uiManager.ShowPlayerChoice(choice);
        gameLogic.SetPlayerChoice(choice);
    }

    public void Shoot()
    {
        if (!canPlay) return;
        canPlay = false;
        uiManager.EnableReplay(true);
        gameLogic.GenerateComputerChoice();
        uiManager.ShowComputerChoice(gameLogic.ComputerChoice.ToString());

        string result = gameLogic.DetermineWinner();
        uiManager.UpdateScores(gameLogic.PlayerScore, gameLogic.ComputerScore);
        uiManager.DisplayResult(result);
    }

    public void Replay()
    {
        canPlay = true;
        uiManager.ResetUI();
        gameLogic.ResetChoices();
    }

    public void QuitClicked()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        string finalMessage = gameLogic.GetFinalResult();
        uiManager.ShowGameOverPanel(finalMessage);
        yield return new WaitForSeconds(3f);
        sceneManager.LoadMainMenu();
    }


}
