using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Rendering.MaterialUpgrader;

public class SetTextPosition : MonoBehaviour
{
    
    [SerializeField] Camera mainCam;
    public Transform charPos;
    public Vector2 offset;
    public int speakID;
    
    
    public void SetTextPos(DialogueLine line)
    {
        if(speakID == line.correctID)
        {
            Vector2 worldPos = (Vector2)charPos.position + offset;
            Vector2 screenPos = mainCam.WorldToScreenPoint(worldPos);
            DialogueManager.Instance.textBox.rectTransform.position = screenPos;
        }
        
    }



}
