using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D.IK;
using UnityEngine.UI;




public class DialogueManagement : MonoBehaviour
{
    public static DialogueManagement instance;
    public TextMeshProUGUI dialogueText;
    [SerializeField] private TMP_FontAsset fontAsset;
    [SerializeField] Button nextButton;
    public bool isTyping;
    public bool inBattle;
    private Coroutine dialogueCoroutine;
    private SetTextPosition[] setTextPositions;
    public DialogueChunk currentChunk;
    private CharacterAnimationController[] characterAnimationControllers; 
    public int messageIndex = 0;
    [SerializeField] RectTransform imageRect;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] bool onScreen;
    private SetTextPosition stp;
    [SerializeField] Camera cam;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public void SetChunk(DialogueChunk chunky)
    {
        
        if (chunky == null) return;
        currentChunk = chunky;
        messageIndex = 0;
        MoveToNext();

    }
    public void Start()
    {
        characterAnimationControllers = GameObject.FindObjectsByType<CharacterAnimationController>(FindObjectsSortMode.None);
        setTextPositions = GameObject.FindObjectsByType<SetTextPosition>(FindObjectsSortMode.None);
        
        nextButton.gameObject.SetActive(false);
        StartTyping();
        
        
    }

    public void MoveToNext()
    {
        if (currentChunk == null) return;
        if (messageIndex >= currentChunk.lines.Count)
        {
            EndDialogue();
        }
        else
        {
            StartTyping();
        }
            
    }

    public void StartTyping()
    {
        if(currentChunk == null) return;
        
        if (messageIndex >= currentChunk.lines.Count) return;
        var line = currentChunk.lines[messageIndex];
        
        isTyping = true;
        
        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        dialogueCoroutine = StartCoroutine(TypingCoroutine(line));
        CallAnimation();

    }
    IEnumerator TypingCoroutine(DialogueLine line)
    {
        
        stp = setTextPositions.FirstOrDefault(x => x.charID == line.charIDRequirement);
        LateUpdate();
        if (stp != null)
        {
            stp.dialogueText.color = line.speak.dialogueColor;
            stp.dialogueText.outlineColor = line.speak.dialogueOutlineColor;
            stp.dialogueText.text = "";
        }
        
        foreach (char c in line.text)
            {
                stp.dialogueText.text += c;
                yield return new WaitForSecondsRealtime(line.typingSpeed);
            }

        
        isTyping = false;
        messageIndex++;
        dialogueCoroutine = null;
        yield return new WaitForSecondsRealtime(line.typingDelay);
        stp.dialogueText.gameObject.SetActive(false);
        MoveToNext();
    }

    public void EndDialogue()
    {
        
        currentChunk = null;
        messageIndex = 0;
        ActivateNext();
    }

    public void ActivateNext()
    {
        if (nextButton == null) return;
        nextButton.gameObject.SetActive(true);
    }

    public void CallAnimation()
    {
        if (currentChunk == null || currentChunk.animEvents == null) return;
        if (messageIndex >= currentChunk.animEvents.Count) return;

        AnimEvent animEvent = currentChunk.animEvents[messageIndex];

        if (animEvent.clipList == null || animEvent.clipList.Count == 0) return;

        foreach (var animScript in characterAnimationControllers)
        {
            foreach (var clip in animEvent.clipList)
            {
                if(animScript.animator!=null)
                animScript.animator.CrossFade(clip.name, animScript.translationDuration);
            }
        }
    }

    private void LateUpdate()
    {
        Vector2 canvasPos;
        
        if (stp == null) return;
        stp.dialogueText.gameObject.SetActive(true);
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, cam.WorldToScreenPoint((Vector2)stp.charPos.position + stp.offset), null, out canvasPos);
        Vector3 screenPos = cam.WorldToScreenPoint(stp.charPos.position);

        bool onScreen = screenPos.x > 0 && screenPos.y > 0 && screenPos.x < Screen.width && screenPos.y < Screen.height && screenPos.z > 0;

        if (onScreen)
        {
            stp.dialogueText.rectTransform.localPosition = canvasPos;
        }
        else
        {
            stp.dialogueText.rectTransform.position = imageRect.position;
        }
        
    }
}
