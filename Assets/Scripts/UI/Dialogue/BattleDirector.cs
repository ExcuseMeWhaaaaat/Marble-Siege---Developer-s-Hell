using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class BattleDirector : MonoBehaviour
{
    public enum TutorialEvents
    {
        WasHit,
        UsedStars,
        UsedScythe,
        Enough,

    }

    public bool[] isDone;
    
    public static BattleDirector instance;
    
    [SerializeField] DialogueChunk chunk;
    [SerializeField] int messagesSent;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        DialogueManager.Instance.StartDialogue(chunk);
        
    }
    public void DetermineMessage(TutorialEvents tutorialEvent, int messageIndex)
    {
        int eventIndex = (int)tutorialEvent;
        string messagePlayed = chunk.lines[messageIndex].text;
        
        if (!isDone[eventIndex])
        {
            
            DialogueManager.Instance.ShowNextBattleLine(messagePlayed);
            DialogueManager.Instance.SpeakStyle(chunk.lines[messageIndex].speak);
            isDone[eventIndex] = true;
        }
        
    }

    public void InvokeMessage()
    {

    }

}
