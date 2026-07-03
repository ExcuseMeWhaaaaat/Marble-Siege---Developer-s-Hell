using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public enum DialogueMode
    {
        Cutscene,
        Battle,
    }

    public DialogueMode dialogueMode;

    //Entire thing was copy and pasted
    public static DialogueManager Instance;

    [Header("UI")]
    public TextMeshProUGUI textBox;
    [SerializeField] private DialogueChunk currentChunk;

    
    private Coroutine typingRoutine;
    public Coroutine anotherTypingRoutiune;
    private Coroutine repeatCoroutine;
    
    public bool isTyping;
    public bool autoAdvance;
    public int messageIndex;
    

    [SerializeField] float delay;

    
    public Button nextButton;


    
    [SerializeField] private List<SetTextPosition> setTextPosition;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nextButton.gameObject.SetActive(false);
        messageIndex = 0;
        
    }
    public void StartDialogue(DialogueChunk chunk)
    {
        currentChunk = chunk;
        var yetAnotherLine = currentChunk.lines[messageIndex];

    }
    
    //Show Next Line
    public void ShowNextLine()
    {
        if (isTyping)
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
            nextButton.gameObject.SetActive(true);
            return;
        }

        
        Debug.Log(messageIndex + " at " + currentChunk.lines[messageIndex].text);

        
    }
    public void ShowNextBattleLine(string lineToShow, Speaking speak3)
    {
        
        if(ScriptedTutorial.instance != null)
        {
            if (isTyping) return; 
            var anotherline = new DialogueLine();
            anotherline.text = lineToShow;
            anotherline.speak = speak3;
            anotherTypingRoutiune = StartCoroutine(TypeBattleLine(anotherline));
            
        }
            
    }
    
    public void SpeakStyle(Speaking speak)
    {
        Debug.Log(speak);
        if (speak == null) 
        {
            return;
        }
        textBox.color = speak.dialogueColor;
        textBox.font = speak.dialogueFont;
        
    }
    public IEnumerator TypeLine(DialogueLine line)
    {
        Debug.Log($"Typing line {messageIndex} / Count {currentChunk.lines.Count}");
        isTyping = true;
        SpeakStyle(line.speak);
        
        
        textBox.text = "";
        

        foreach (var stp in setTextPosition)
        {
            stp.SetTextPos(line);
        }
        Debug.Log(currentChunk.lines[messageIndex].text);
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
        messageIndex++;
        if (!autoAdvance)
        {
            yield break;
        }
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
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
        ShowNextLine();
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
    
    
}
