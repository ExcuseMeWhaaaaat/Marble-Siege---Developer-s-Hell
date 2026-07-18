using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEditor;

public class CharacterAnimationController : MonoBehaviour
{
    
    public Animator animator;
    
    public float translationDuration;
    public int charID;

    
    
    public void PlayAnimation(AnimationClip clip)
    {
        
        
        int stateHash = Animator.StringToHash(clip.name);
        
        Debug.Log($"Playing: {clip.name}");
        animator.CrossFade(stateHash, translationDuration);
        
    }
}
