using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEditor;


public class DialogueManagement : MonoBehaviour
{
    public enum DialogueMode
    {
        Cutscene,
        Battle,
    }

    public DialogueMode dialogueMode;

    //Entire thing was copy and pasted
    public static DialogueManagement Instance;

    [Header("UI")]
    public TextMeshProUGUI textBox;
    [SerializeField] private ChunkDialogue currentChunk;
    [SerializeField] TextMeshProUGUI lineCountText;

    public Coroutine typingRoutine;
    public Coroutine anotherTypingRoutiune;
    
    
    public bool isTyping;
    public bool autoAdvance;
    public int messageIndex;
    [SerializeField] int maxLines;


    [SerializeField] float delay;

    
    


    
    [SerializeField] private List<SetTextPosition> setTextPosition;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(dialogueMode != DialogueMode.Battle)
        {
            Time.timeScale = 1;
        }
        
        
        messageIndex = 0;
        UpdateLine();

    }
    public void StartDialogue(ChunkDialogue chunk)
    {
        currentChunk = chunk;
        var yetAnotherLine = currentChunk.lines[messageIndex];

    }
    
    //Show Next Line
    public void ShowNextLine()
    {
        
        if (isTyping || !autoAdvance)
        {
            SkipTyping();
            return;
        }
        if (currentChunk == null) return;
        if (dialogueMode == DialogueMode.Battle)
        {
            return; 
        }
        if (messageIndex >= currentChunk.lines.Count)
        {
            Debug.Log("Enough");
            
            return;
        }
        UpdateLine();
        

        
    }
    public void ShowNextBattleLine(string lineToShow, Speaking speak3)
    {
            if (isTyping) return; 
            var anotherline = new DialogueLine();
            anotherline.text = lineToShow;
            anotherline.speak = speak3;
            anotherTypingRoutiune = StartCoroutine(TypeBattleLine(anotherline));
            
        
            
    }
    
    public void SpeakStyle(Speaking speak)
    {
        
        if (speak == null) 
        {
            return;
        }
        textBox.color = speak.dialogueColor;
        textBox.font = speak.dialogueFont;
        
    }
    public IEnumerator TypeLine(DialogueLine line)
    {
        
        isTyping = true;
        SpeakStyle(line.speak);
        
        
        textBox.text = "";

        foreach (var stp in setTextPosition)
        {
            stp.SetTextPos(line);
        }


        foreach (char c in line.text)
        {
           
            textBox.text += c;
            if (SoundManagement.instance != null)
            {
                SoundManagement.instance.audioSource.PlayOneShot(line.speak.speakerVoice, SoundManagement.instance.masterVol);
            }
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(currentChunk.lines[messageIndex].typeDelay);
        isTyping = false;
        
        if (!autoAdvance)
        {
            yield break;
        }
        
        messageIndex++;
        ShowNextLine();

    }

    public IEnumerator TypeBattleLine(DialogueLine line)
    {
        isTyping = true;

        SpeakStyle(line.speak);
        textBox.text = "";

        foreach (char c in line.text)
        {
            textBox.text += c;
            if (SoundManagement.instance != null)
            {
                SoundManagement.instance.audioSource.PlayOneShot(line.speak.speakerVoice, SoundManagement.instance.masterVol);
            }
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
        
    }
    public void SkipTyping()
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
            typingRoutine = null;

        }
        textBox.text = currentChunk.lines[messageIndex].text;
        isTyping = false;
    }

    public void StopDialogue()
    {
        textBox.gameObject.SetActive(false);
        

    }

    public void UpdateLine()
    {
        if (lineCountText == null) return;
        lineCountText.text = "Line " + messageIndex.ToString() + "/" + maxLines;
    }
}
