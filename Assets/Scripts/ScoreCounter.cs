using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _computerScoreText;
    private int playerScore;
    private int computerScore;

    public void IncreasePlayerScore()
    {
        playerScore++;
        _playerScoreText.text = playerScore.ToString();
    }

    public void IncreaseComputerScore()
    {
        computerScore++;
        _computerScoreText.text = computerScore.ToString();
    }
}
