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
        foreach (var theCharacter in FindObjectsByType<CharacterAnimationController>())
        { 
            if(!characters.ContainsKey(theCharacter.charID))
            characters.Add(theCharacter.charID,theCharacter);
        }
        
        
        
    }

    
    public IEnumerator PlayCoroutine()
    {
        var line = chunk.lines;

        if (DialogueManager.Instance == null) yield break;

        if (!DialogueManager.Instance.autoAdvance)
        {

            yield return new WaitUntil(() => Keyboard.current.zKey.wasPressedThisFrame);

        }
        
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
                character.PlayAnimation(animation.animationState);
            }
            else
            {
                Debug.Log("No");
                Debug.Log(animation.animID);
                Debug.Log(character);
            }
        }
    }
    public void Play()
    {
        if (!DialogueManager.Instance.isTyping)
        {
            
            StartCoroutine(PlayCoroutine());
        }
        
        
    }

    public void ManualAdvance(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (DialogueManager.Instance.isTyping) return;
        
        

    }
}
