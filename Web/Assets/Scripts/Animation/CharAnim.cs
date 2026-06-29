using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEditor;

public class CharacterAnimationController : MonoBehaviour
{
    
    public Animator animator;
    
    public float translationDuration;
    public int charID;
    public void PlayAnimation(string state)
    {
        if (state == null || string.IsNullOrEmpty(state)) return; 
        animator.CrossFade(state, translationDuration);
    }
}
