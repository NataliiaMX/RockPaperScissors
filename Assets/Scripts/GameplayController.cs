using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Sprite rock;
    [SerializeField] private Sprite paper;
    [SerializeField] private Sprite scissors;
    [SerializeField] private Image playerChoiceImage;
    [SerializeField] private Image computerChoiceImage;
    [SerializeField] private TMPro.TextMeshProUGUI _infoText;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private ScoreCounter _scoreCounter;
    private string playerChoice;
    private string computerChoice;
    private float secondsToWait = 2f;
    
    public void SetChoices(string selectedPlayerChoice)
    {
        switch(selectedPlayerChoice)
        {
            case "Rock":
            playerChoiceImage.sprite = rock;
            playerChoice = "Rock";
              break;

            case "Paper":
            playerChoiceImage.sprite = paper;
            playerChoice = "Paper";
              break;

            case "Scissors":
            playerChoiceImage.sprite = scissors;
            playerChoice = "Scissors";
              break;
        }

        SetComputerChoice();
        DetermineWinner();
    }

    private void DetermineWinner()
    {
        if (playerChoice == computerChoice)
        {
            HandleTie();
        }
        else if (playerChoice == "Paper" && computerChoice == "Rock" 
                 || playerChoice == "Rock" && computerChoice == "Scissors"
                 || playerChoice == "Scissors" && computerChoice == "Paper")
        {
            HandleWin();
        }
        else if (playerChoice == "Rock" && computerChoice == "Paper" 
                 || playerChoice == "Scissors" && computerChoice == "Rock"
                 || playerChoice == "Paper" && computerChoice == "Scissors")
        {
            HandleLoss();
        }
    }

    IEnumerator DisplayWinnerAndRestart ()
    {
        yield return new WaitForSeconds(secondsToWait);
        _infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(secondsToWait);
        _infoText.gameObject.SetActive(false);

        _animationController.RestartAnimations();
    }

    private void SetComputerChoice()
    {
        int rnd = UnityEngine.Random.Range(0, 3);
        
        switch(rnd) 
            {
                case 0:
                computerChoiceImage.sprite = rock;
                computerChoice = "Rock";
                  break;

                case 1:
                computerChoiceImage.sprite = paper;
                computerChoice = "Paper";
                  break;

                case 2:
                computerChoiceImage.sprite = scissors;
                computerChoice = "Scissors";
                  break;
            }
    }
    
    private void HandleWin()
    {
        _infoText.text = "You win!";
        StartCoroutine(DisplayWinnerAndRestart());
        _scoreCounter.IncreasePlayerScore();
    }

    private void HandleLoss()
    {
        _infoText.text = "You lost!";
        StartCoroutine(DisplayWinnerAndRestart());
        _scoreCounter.IncreaseComputerScore();
    }

    private void HandleTie()
    {
        _infoText.text = "It's a tie!";
        StartCoroutine(DisplayWinnerAndRestart());
    }
}
