using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScriptedTutorial : MonoBehaviour
{
    public enum TutorialEvents
    {
        Intro1,
        TryHitBoss,
        Intro3,
        Heal,
        Ally,
        PointOut,
        UseMe,
        Acyd,
    }


    public List<TutorialEvents> tutorialEvents;
    public Dictionary<TutorialEvents,bool> completeEv;
    public static ScriptedTutorial instance;
    public DialogueChunk scriptedChunk;
    public float timer;
    
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
        completeEv.Add(TutorialEvents.UseMe, false);
        completeEv.Add(TutorialEvents.Acyd, false);
        completeEv.Add(TutorialEvents.Intro1, false);
        completeEv.Add(TutorialEvents.TryHitBoss,false);
        CompleteEvent(TutorialEvents.Intro1, 0);
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
    }

    public void CompleteEvent(TutorialEvents eventName, int lineIndex)
    {
        if (DialogueManager.Instance == null) return;
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
