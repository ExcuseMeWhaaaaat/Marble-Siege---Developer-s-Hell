using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class BattleDialogue : MonoBehaviour
{
    public enum Done
    {
        Finished
    }
    
    public ChunkDialogue battleChunk;
    public List<int> speakHP;
    public static BattleDialogue instance;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        DialogueManagement.Instance.ShowNextBattleLine(battleChunk.lines[0].text, battleChunk.lines[0].speak);
    }


}
