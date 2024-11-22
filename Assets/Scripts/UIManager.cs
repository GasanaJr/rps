using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image playerChoiceImage;
    public Image computerChoiceImage;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI computerScoreText;
    public GameObject panel;
    public Button replayButton;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    public void InitializeUI()
    {
        replayButton.interactable = false;
        resultText.text = "Rock, Paper, or Scissors!";
        ResetChoiceImages();
        panel.SetActive(false);
    }

    public void ResetUI()
    {
        InitializeUI();
    }

    public void ShowPlayerChoice(string choice)
    {
        playerChoiceImage.enabled = true;
        playerChoiceImage.sprite = GetSprite(choice);
    }

    public void ShowComputerChoice(string choice)
    {
        computerChoiceImage.enabled = true;
        computerChoiceImage.sprite = GetSprite(choice);
    }

    public void UpdateScores(int playerScore, int computerScore)
    {
        playerScoreText.text = $"Score: {playerScore}";
        computerScoreText.text = $"Score: {computerScore}";
    }

    public void DisplayResult(string result)
    {
        resultText.text = result;
    }

    public void ShowGameOverPanel(string finalMessage)
    {
        gameOverText.text = finalMessage;
        panel.SetActive(true);
    }

    public void EnableReplay(bool enable)
    {
        replayButton.interactable = enable;
    }

    private Sprite GetSprite(string choice)
    {
        return choice switch
        {
            "Rock" => rockSprite,
            "Paper" => paperSprite,
            "Scissors" => scissorsSprite,
            _=> null,
        };
    }

    private void ResetChoiceImages()
    {
        playerChoiceImage.enabled = false;
        computerChoiceImage.enabled = false;
        playerChoiceImage.sprite = null;
        computerChoiceImage.sprite = null;
    }

}
