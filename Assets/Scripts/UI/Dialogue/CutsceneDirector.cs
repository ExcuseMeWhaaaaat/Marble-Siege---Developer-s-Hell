using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;


public class CutsceneDirector : MonoBehaviour
{
    
    public DialogueChunk chunk;
    private Dictionary<int,CharacterAnimationController> characters;
    [SerializeField] private CutsceneSteps cutscene;
    public int stepIndex;
    
    
   
    
    private void Awake()
    {
        if (DialogueManager.Instance == null) return;
        
        characters = new Dictionary<int,CharacterAnimationController>();
        foreach (var theCharacter in FindObjectsByType<CharacterAnimationController>(FindObjectsSortMode.None))
        {
            characters.Add(theCharacter.charID,theCharacter);
        }
        
        DialogueManager.Instance.autoAdvance = true;
        
    }

    
    public IEnumerator PlayCoroutine()
    {
        var line = chunk.lines;

        
            
        for (stepIndex = 0; stepIndex < cutscene.steps.Count; stepIndex++)
        {
            if (stepIndex >= line.Count)
            {
                
                yield break;
            }
            ExecuteAnimation(stepIndex);
            yield return DialogueManager.Instance.TypeLine(line[stepIndex]);
            
            
            
        }
        
    }
    public void ExecuteAnimation(int index)
    {
        if (characters == null) return;
        var step = cutscene.steps[stepIndex];
        foreach (var animation in step.animationChunks)
        {
            if (characters.TryGetValue(animation.animID, out var character))
            {
                character.PlayAnimation(animation.animationState.name);
            }
        }
    }
    public void Play()
    {
        ExecuteAnimation(stepIndex);
        StartCoroutine(PlayCoroutine());
        
    }

    
}
