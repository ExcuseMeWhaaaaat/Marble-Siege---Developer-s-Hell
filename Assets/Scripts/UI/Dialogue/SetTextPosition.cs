using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SetTextPosition : MonoBehaviour
{
    
    [SerializeField] Camera mainCam;
    public Transform charPos;
    public Vector2 offset;
    public int speakID;
    private Vector2 worldPos;
    private Vector3 screenPos;
    private Vector2 targetPos;
    public RectTransform canvasRect;
    public RectTransform textRect;
    private Vector2 currentVel;
    private bool following;
    

    public void SetTextPos(DialogueLine line)
    {
            following = (speakID == line.correctID);
        
        
    }

    

    void LateUpdate()
    {
        if (!following) return;
        
        worldPos = (Vector2)charPos.position + offset;
        screenPos = RectTransformUtility.WorldToScreenPoint(mainCam, worldPos);
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect,screenPos,null,out localPos);
        targetPos = localPos;

        targetPos.x = Mathf.RoundToInt(targetPos.x);
        targetPos.y = Mathf.RoundToInt(targetPos.y);

        textRect.anchoredPosition = Vector2.SmoothDamp(textRect.anchoredPosition, targetPos,ref currentVel, 0.25f);
       
       
        
    }

}
