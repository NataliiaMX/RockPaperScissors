using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerScoreText, computerScoreText;
    int playerScore = 0;
    int computerScore = 0;

    public void IncreasePlayerScore ()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }

    public void IncreaseComputerScore ()
    {
        computerScore++;
        computerScoreText.text = computerScore.ToString();
    }
}
