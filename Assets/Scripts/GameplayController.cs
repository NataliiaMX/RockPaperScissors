using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameplayController : MonoBehaviour
{
    [SerializeField] Sprite rock_Sprite, paper_Sprite, scissors_Sprite;
    [SerializeField] Image playerChoice_IMG, computerChoice_IMG;
    [SerializeField] TMPro.TextMeshProUGUI infoText;
    [SerializeField] GameObject[] rpsArray;

    string playerChoice;
    string computerChoice;
    int randomInt;
    AnimationController animationController;
    ScoreCounter scoreCounter;

    private void Awake() 
    {
        animationController = GetComponent<AnimationController>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    public void SetChoices(string selectedPlayerChoice)
    {
        switch (selectedPlayerChoice)
        {
            case "Rock":
            playerChoice_IMG.sprite = rock_Sprite;
            playerChoice = "Rock";
            break;

            case "Paper":
            playerChoice_IMG.sprite = paper_Sprite;
            playerChoice = "Paper";
            break;

            case "Scissors":
            playerChoice_IMG.sprite = scissors_Sprite;
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
            infoText.text = "It's a tie!";
            StartCoroutine("DisplayWinnerAndRestart");
            return;
        }
        if (playerChoice == "Paper" && computerChoice == "Rock")
        {
            infoText.text = "You win!";
            StartCoroutine("DisplayWinnerAndRestart");
            scoreCounter.IncreasePlayerScore();
            return;
        }
        if (playerChoice == "Rock" && computerChoice == "Paper")
        {
            infoText.text = "You lost!";
            StartCoroutine(DisplayWinnerAndRestart());
            scoreCounter.IncreaseComputerScore();
            return;
        }
        if (playerChoice == "Rock" && computerChoice == "Scissors")
        {
            infoText.text = "You win!";
            StartCoroutine(DisplayWinnerAndRestart());
            scoreCounter.IncreasePlayerScore();
            return;
        }
        if (playerChoice == "Scissors" && computerChoice == "Rock")
        {
            infoText.text = "You lost!";
            StartCoroutine(DisplayWinnerAndRestart());
            scoreCounter.IncreaseComputerScore();
            return;
        }
        if (playerChoice == "Scissors" && computerChoice == "Paper")
        {
            infoText.text = "You win!";
            StartCoroutine(DisplayWinnerAndRestart());
            scoreCounter.IncreasePlayerScore();
            return;
        }
        if (playerChoice == "Paper" && computerChoice == "Scissors")
        {
            infoText.text = "You lost!";
            StartCoroutine("DisplayWinnerAndRestart");
            scoreCounter.IncreaseComputerScore();
            return;
        }
        
    }

    IEnumerator DisplayWinnerAndRestart ()
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.RestartAnimations();
    }

    private void SetComputerChoice()
    {
        int rnd = UnityEngine.Random.Range(0, 3);
        
        switch (rnd) 
            {
                case 0:
                computerChoice_IMG.sprite = rock_Sprite;
                computerChoice = "Rock";
                break;

                case 1:
                computerChoice_IMG.sprite = paper_Sprite;
                computerChoice = "Paper";
                break;

                case 2:
                computerChoice_IMG.sprite = scissors_Sprite;
                computerChoice = "Scissors";
                break;
            }
    }
    
}
