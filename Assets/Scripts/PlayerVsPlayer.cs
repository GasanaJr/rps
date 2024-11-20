using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerVsPlayer : MonoBehaviour
{
    public Image player1Choice;
    public Image player2Choice;
    public TextMeshProUGUI resultText;

    public Button shoot;
    public Button replay;

    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    private Choices player1;
    private Choices player2;
    private bool canPlay = true;
    private bool isPlayer1Turn = true;
    public TextMeshProUGUI playerScore;
    private int playerCount = 0;
    public TextMeshProUGUI player2Score;
    private int player2Count = 0;

    void Start()
    {
        replay.interactable = false;
        resultText.text = "Player 1: Make your choice!";
        player1Choice.GetComponent<Image>().enabled = false;
        player2Choice.GetComponent<Image>().enabled = false;
        player1Choice.sprite = null;
        player2Choice.sprite = null;
        Cursor.visible = false;
    }

    private void Update()
    {
        GetPlayerChoice();
    }

    private void GetPlayerChoice()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha7)) 
        {
            SetPlayerChoice("Rock");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetPlayerChoice("Paper");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetPlayerChoice("Scissors");
        }
    }

    public void SetPlayerChoice(string choice)
    {
        if (!canPlay) return;

        if (isPlayer1Turn)
        {
            Cursor.visible = false;
            player1Choice.GetComponent<Image>().enabled = false;
            player1 = (Choices)System.Enum.Parse(typeof(Choices), choice, true);
            resultText.text = "Player 2: Make your choice!";
            isPlayer1Turn = false;
        } else
        {
            player2 = (Choices)System.Enum.Parse(typeof(Choices), choice, true);
            Cursor.visible = true;
            player2Choice.GetComponent<Image>().enabled = false;
            resultText.text = "Shoot to Check Winner!";
        }
    }

    public void Shoot()
    {
        if (!canPlay) return;
        canPlay = false;
        replay.interactable = true;
        player1Choice.GetComponent<Image>().enabled = true;
        AssignSprite(player1Choice, player1);
        player2Choice.GetComponent<Image>().enabled = true;
        AssignSprite(player2Choice, player2);

        string result = DetermineWinner(player1, player2);
        resultText.text = result;
    }

    private void AssignSprite(Image image, Choices choice)
    {
        switch (choice)
        {
            case Choices.Rock:
                image.sprite = rock;
                break;
            case Choices.Paper:
                image.sprite = paper;
                break;
            case Choices.Scissors:
                image.sprite = scissors;
                break;
        }

    }

    private string DetermineWinner(Choices player, Choices player2)
    {
        if (player == player2) return "It's a draw!";
        if ((player == Choices.Rock && player2 == Choices.Scissors) ||
            (player == Choices.Scissors && player2 == Choices.Paper) ||
            (player == Choices.Paper && player2 == Choices.Rock))
        {
            playerCount++;
            playerScore.text = $"Score: {playerCount}";
            return "Player1 Wins!";
        }
        else
        {
            player2Count++;
            player2Score.text = $"Score: {player2Count}";
            return "Player2 Wins!";
        }
    }

    public void Replay()
    {
        canPlay = true;
        isPlayer1Turn = true;
        replay.interactable = false;
        player1Choice.GetComponent<Image>().enabled = false;
        player2Choice.GetComponent<Image>().enabled = false;
        resultText.text = "Player 1: Make your choice!";
        GetPlayerChoice();
    }

    public enum Choices
    {
        Rock,
        Paper,
        Scissors
    }
}
