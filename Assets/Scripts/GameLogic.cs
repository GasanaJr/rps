using UnityEngine;

public class GameLogic 
{
    public enum Choices { Rock, Paper, Scissors }

    private Choices playerChoice;
    private Choices computerChoice;
    private int playerScore = 0;
    private int computerScore = 0;

    public Choices ComputerChoice => computerChoice;
    public int PlayerScore => playerScore;
    public int ComputerScore => computerScore;

    public void SetPlayerChoice(string choice)
    {
        playerChoice = (Choices)System.Enum.Parse(typeof(Choices), choice, true);
    }

    public void GenerateComputerChoice()
    {
        computerChoice = (Choices)Random.Range(0, 3);
    }

    public string DetermineWinner()
    {
        if (playerChoice == computerChoice) return "It's a Draw";
        if ((playerChoice == Choices.Rock && computerChoice == Choices.Scissors) ||
            (playerChoice == Choices.Scissors && computerChoice == Choices.Paper) ||
            (playerChoice == Choices.Paper && computerChoice == Choices.Rock))
        {
            playerScore++;
            return "Player Wins!";
        }
        else
        {
            computerScore++;
            return "Computer Wins!";
        }
    }

    public void ResetChoices()
    {
        playerChoice = default;
        computerChoice = default;
    }

    public string GetFinalResult()
    {
        if (playerScore > computerScore) return "Player Wins the Game!";
        if (computerScore > playerScore) return "Computer Wins the Game!";
        return "It's a Draw!";
    }

}
