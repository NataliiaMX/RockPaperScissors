using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationController : MonoBehaviour
{
   [SerializeField] Animator playerChoiceAnimator, desicionAnimator;

   public void RestartAnimations ()
   {
        playerChoiceAnimator.Play("ShowHandler");
        desicionAnimator.Play("RemoveChoices");
   }

   public void HandlePlayerChoice ()
   {
        playerChoiceAnimator.Play("RemoveHandler");
        desicionAnimator.Play("ShowChoices");
   }
}
