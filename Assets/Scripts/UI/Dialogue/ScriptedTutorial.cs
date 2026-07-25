using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;

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
    public ChunkDialogue scriptedChunk;
    public float timer;
    public bool fightEnded = false;
    public float delay;
    public bool isGone = false;
    [SerializeField] private PivotFlyer bossController;
    
    
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

        
        if (DialogueManagement.Instance == null) return;
        
        if (completeEv[eventName]) return;
        
        
        if (!DialogueManagement.Instance.isTyping)
        {
            DialogueManagement.Instance.SpeakStyle(scriptedChunk.lines[lineIndex].speak);
            DialogueManagement.Instance.ShowNextBattleLine(scriptedChunk.lines[lineIndex].text, scriptedChunk.lines[lineIndex].speak);
            completeEv[eventName] = true;


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

        SeeIfGone();
        bossController.ScriptedLeave();
        
        
    }

    public void SetDelay()
    {
        if (fightEnded)
        {
            delay = 1;
            StartCoroutine(WaitForDialogue());
        }
           
    }

    public void SeeIfGone()
    {
        if (isGone) return;
        isGone = true;
    }

}
