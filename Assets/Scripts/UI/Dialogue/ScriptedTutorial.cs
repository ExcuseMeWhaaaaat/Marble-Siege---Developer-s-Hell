using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScriptedTutorial : MonoBehaviour
{
    public enum TutorialEvents
    {
        Intro1,
        BossDone,
        Heal,
        Ally,
        Acyd,
        NotRecommended,
    }


    
    public Dictionary<TutorialEvents,bool> completeEv;
    
    public static ScriptedTutorial instance;
    public DialogueChunk scriptedChunk;
    public float timer;
    public bool fightEnded = false;
    public float delay;
    
    
    private void Awake()
    {
        completeEv = new Dictionary<TutorialEvents, bool>();
        
        if(instance != null && instance != this )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        
        foreach(TutorialEvents ev in System.Enum.GetValues(typeof(TutorialEvents)))
        {
            completeEv[ev] = false;
        }
        CompleteEvent(TutorialEvents.Intro1, 0);
        
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        
    }

    public void CompleteEvent(TutorialEvents eventName, int lineIndex)
    {

        
        if (DialogueManager.Instance == null) return;
        
        if (completeEv[eventName]) return;
        completeEv[eventName] = true;
        
        if (!DialogueManager.Instance.isTyping)
        {
            DialogueManager.Instance.SpeakStyle(scriptedChunk.lines[lineIndex].speak);
            DialogueManager.Instance.ShowNextBattleLine(scriptedChunk.lines[lineIndex].text, scriptedChunk.lines[lineIndex].speak);
            
            
            
        }
        

    }

    IEnumerator WaitForDialogue()
    {
        while (delay > 0)
        {
            yield return new WaitForSeconds(1f);
            delay--;
        }
        CompleteEvent(TutorialEvents.BossDone, 4);
        DialogueManager.Instance.nextButton.gameObject.SetActive(true);
        
        
    }

    public void SetDelay()
    {
        if (fightEnded)
        {
            delay = 3;
            StartCoroutine(WaitForDialogue());
        }
           
    }

}
