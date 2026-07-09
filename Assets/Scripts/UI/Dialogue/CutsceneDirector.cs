using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
        
        
        
    }

    
    public IEnumerator PlayCoroutine()
    {
        var line = chunk.lines;

        if (DialogueManager.Instance == null) yield break;
            
        for (stepIndex = 0; stepIndex < cutscene.steps.Count; stepIndex++)
        {
            if (stepIndex >= line.Count)
            {
                
                yield break;
            }

            if (!DialogueManager.Instance.autoAdvance)
            {
                Debug.Log("Yield Broken!");
                yield return new WaitUntil(() => Keyboard.current.zKey.wasPressedThisFrame);

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
        if (!DialogueManager.Instance.isTyping)
        {
            Debug.Log("Played");
            StartCoroutine(PlayCoroutine());
        }
        
        
    }

    public void ManualAdvance(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (DialogueManager.Instance.isTyping) return;
        
        

    }
}
