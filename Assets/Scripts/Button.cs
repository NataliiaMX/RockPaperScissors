using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    AnimationController animationController;
    GameplayController gameplayController;
    bool isPressed = false;
    string choiceTag;

    private void Start() 
    {
        animationController = FindObjectOfType<AnimationController>();
        gameplayController = FindObjectOfType<GameplayController>();
    }
    private void Update() 
    {
        if (isPressed)
        {
            choiceTag = transform.tag;
            gameplayController.SetChoices(choiceTag);
            animationController.HandlePlayerChoice();
            isPressed = false;
        }
    }

    public void ToggleIsPressed ()
    {
        isPressed = true;
    }
}
