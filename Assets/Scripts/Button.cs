using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private GameplayController _gameplayController;
    private string choiceTag;

    public void DoWhenClicked()
    {
        choiceTag = transform.tag;
        _gameplayController.SetChoices(choiceTag);
        _animationController.HandlePlayerChoice();
    }
}
