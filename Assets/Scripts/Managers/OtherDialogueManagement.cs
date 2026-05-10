using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
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
    private Coroutine anotherTypingRoutiune;
    
    public bool isTyping;
    public bool autoAdvance;
    public int messageIndex = 0;
    


    [SerializeField] float delay;

    [SerializeField] TypePresentation dialoguePresent;
    [SerializeField] Button nextButton;


    [SerializeField] int totalMessages;
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
        ShowNextLine();
        typingRoutine = StartCoroutine(TypeLine(yetAnotherLine));
        Debug.Log("Started Coroutine!");
        
        
        
    }
    
    //Show Next Line
    public void ShowNextLine()
    {
        if (isTyping)
        {
            SkipTyping();
            return ;
        }
        if(messageIndex >= currentChunk.lines.Count)
        {
            EndDialogue();
            return ;
        }
        Debug.Log("Returned True!");
        return ;
        
    }

    
    public void ShowNextBattleLine(string lineToShow)
    {
        if (isTyping) return;
        
        var anotherline = new DialogueLine();
         anotherline.text = lineToShow;
         
         anotherTypingRoutiune = StartCoroutine(TypeLine(anotherline));
            
    }
    
    public void SpeakStyle(Speaking speak)
    {
        
        if (speak == null) 
        {
            Debug.Log("No speaker!");
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
        Debug.Log("On Coroutine!");
        
        foreach(var stp in setTextPosition)
        {
            stp.SetTextPos(line);
        }
        
        foreach (char c in line.text)
        {
            textBox.text += c;
            yield return new WaitForSecondsRealtime(dialoguePresent.typingSpeed);
        }

        isTyping = false;
        if (autoAdvance)
        {
            yield return new WaitForSeconds(dialoguePresent.typingDelay);
            
            Debug.Log("Auto Advanced!");
            
        }
        ShowNextLine();

    }
    
    
    public void SkipTyping()
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
            typingRoutine = null;
            Debug.Log("Stopped");
            textBox.text = textBox.text;
            isTyping = false;
        }
            
    }

    void EndDialogue()
    {
        textBox.text = "";
        nextButton.gameObject.SetActive(true);
    }

    
}
