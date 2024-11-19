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

    public enum Choices
    {
        Rock,
        Paper,
        Scissors
    }
}
