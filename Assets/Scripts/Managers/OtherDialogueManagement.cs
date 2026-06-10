using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    

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
    public int messageIndex = 0;
    


    [SerializeField] float delay;

    [SerializeField] TypePresentation dialoguePresent;
    public Button nextButton;


    
    [SerializeField] private List<SetTextPosition> setTextPosition;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nextButton.gameObject.SetActive(false);
        
    }
    public void StartDialogue(DialogueChunk chunk)
    {
        currentChunk = chunk;
        var yetAnotherLine = currentChunk.lines[messageIndex];

        typingRoutine = StartCoroutine(TypeLine(yetAnotherLine));
    }
    
    //Show Next Line
    public void ShowNextLine()
    {
        if (isTyping)
        {
            SkipTyping();
            return;
        }
        if(messageIndex >= currentChunk.lines.Count)
        {
            nextButton.gameObject.SetActive(true);
            return;
        }
        Debug.Log(messageIndex);
        
        
        

    }
    public void ShowNextBattleLine(string lineToShow, Speaking speak3)
    {
        if (isTyping) return;
        
        var anotherline = new DialogueLine();
        anotherline.text = lineToShow;
         anotherline.speak = speak3;
        anotherTypingRoutiune = StartCoroutine(TypeLine(anotherline));
            
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
        
        
        isTyping = true;
        SpeakStyle(line.speak);
        
        
        textBox.text = "";
        
        
        foreach(var stp in setTextPosition)
        {
            stp.SetTextPos(line);
        }
        
        foreach (char c in line.text)
        {
           
            textBox.text += c;
            if (SoundManagement.instance != null)
            {
                SoundManagement.instance.audioSource.PlayOneShot(line.speak.speakerVoice, 0.75f);
            }
            yield return new WaitForSecondsRealtime(dialoguePresent.typingSpeed);
        }
        
        isTyping = false;
        messageIndex++;
        if (!autoAdvance)
        {
            yield break;
        }
        yield return new WaitForSecondsRealtime(dialoguePresent.typingDelay);
        ShowNextLine();

    }
    
    public void SkipTyping()
    {
        if (typingRoutine != null)
        {
            
            typingRoutine = null;
            Debug.Log("Stopped");
            textBox.text = textBox.text;
            
        } 
    }
    
        
    
}
