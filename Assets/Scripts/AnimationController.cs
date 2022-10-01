using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
   [SerializeField] private Animator _playerChoiceAnimator;
   [SerializeField] private Animator _desicionAnimator;
   private string showHandler = "ShowHandler";
   private string removeChoices = "RemoveChoices";
   private string removeHandler = "RemoveHandler";
   private string showChoices = "ShowChoices";

   public void RestartAnimations()
   {
        _playerChoiceAnimator.Play(showHandler);
        _desicionAnimator.Play(removeChoices);
   }

   public void HandlePlayerChoice()
   {
        _playerChoiceAnimator.Play(removeHandler);
        _desicionAnimator.Play(showChoices);
   }
}
