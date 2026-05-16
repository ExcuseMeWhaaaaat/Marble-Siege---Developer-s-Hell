using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScriptedTutorial : MonoBehaviour
{
    public enum TutorialEvents
    {
        Heal,
        Ally,
        PointOut,
    }

    public List<TutorialEvents> tutorialEvents;
    public Dictionary<TutorialEvents,bool> completeEv;
    public static ScriptedTutorial instance;
    public DialogueChunk scriptedChunk;
    
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
        completeEv.Add(TutorialEvents.Heal, false);
        completeEv.Add(TutorialEvents.Ally, false);
        completeEv.Add(TutorialEvents.PointOut, false);
        

    }

    public void CompleteEvent(TutorialEvents eventName, int lineIndex)
    {
        if (!completeEv[eventName])
        {
            completeEv[eventName] = true;
            if (!DialogueManager.Instance.isTyping)
            {
                DialogueManager.Instance.SpeakStyle(scriptedChunk.lines[lineIndex].speak); 
                DialogueManager.Instance.ShowNextBattleLine(scriptedChunk.lines[lineIndex].text);
            }
            
        }
        
        
    }

}
