using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Image playerChoice;
    public Image computerChoice;
    public TextMeshProUGUI resultText;

    public Button shoot;
    public Button replay;

    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    private Choices player;
    private Choices computer;
    private bool canPlay = true;

    public TextMeshProUGUI playerScore;
    private int playerCount = 0;
    public TextMeshProUGUI computerScore;
    private int computerCount = 0;

    void Start()
    {
        replay.interactable = false;
        resultText.text = "Rock, Paper, or Scissors!";
        playerChoice.GetComponent<Image>().enabled = false;
        computerChoice.GetComponent<Image>().enabled = false;
        playerChoice.sprite = null;
        computerChoice.sprite = null;
    }

    public void SetPlayerChoice(string choice)
    {
        if (!canPlay) return;
        playerChoice.GetComponent<Image>().enabled = true;
        

        player = (Choices)System.Enum.Parse(typeof(Choices), choice, true);

        switch (player)
        {
            case Choices.Rock:
                playerChoice.sprite = rock;
                break;
            case Choices.Paper:
                playerChoice.sprite = paper;
                break;
            case Choices.Scissors:
                playerChoice.sprite = scissors;
                break;
        }
    }

    public void Shoot()
    {
        if (!canPlay) return;
        canPlay = false;
        replay.interactable = true;
        computer = (Choices)Random.Range(0, 3);
        computerChoice.GetComponent<Image>().enabled = true;

        switch (computer)
        {
            case Choices.Rock:
                computerChoice.sprite = rock;
                break;
            case Choices.Paper:
                computerChoice.sprite = paper;
                break;
            case Choices.Scissors:
                computerChoice.sprite = scissors;
                break;
        }

        string result = DetermineWinner(player, computer);
        resultText.text = result;
    }

    private string DetermineWinner(Choices player, Choices computer)
    {
        if (player == computer) return "It's a draw!";
        if ((player == Choices.Rock && computer == Choices.Scissors) ||
            (player == Choices.Scissors && computer == Choices.Paper) ||
            (player == Choices.Paper && computer == Choices.Rock))
        {
            playerCount++;
            playerScore.text = $"Score: {playerCount}";
            return "Player Wins!";
        }
        else
        {
            computerCount++;
            computerScore.text = $"Score: {computerCount}";
            return "Computer Wins!";
        }
    }

    public void Replay()
    {
        canPlay = true;
        replay.interactable = false;
        playerChoice.GetComponent<Image>().enabled = false;
        computerChoice.GetComponent<Image>().enabled = false;
        resultText.text = "Rock, Paper, or Scissors!";
    }

    public enum Choices
    {
        Rock,
        Paper,
        Scissors
    }
}
