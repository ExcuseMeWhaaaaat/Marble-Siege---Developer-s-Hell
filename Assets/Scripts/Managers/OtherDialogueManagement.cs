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
    

    public Queue<DialogueLine> lines = new Queue<DialogueLine>();
    private Coroutine typingRoutine;

    public bool isTyping;
    public bool autoAdvance;
    public int messageIndex = 0;
    public bool isPlayng;


    [SerializeField] float delay;

    [SerializeField] TypePresentation dialoguePresent;
    [SerializeField] Button nextButton;
    
    
    [SerializeField] private List<SetTextPosition> setTextPosition;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        nextButton.enabled = false;
    }
    public void StartDialogue(DialogueChunk chunk)
    {
        
        lines.Clear();

        foreach (var line in chunk.lines)
            lines.Enqueue(line);

        ShowNextLine();
    }
    
    //Show Next Line
    public void ShowNextLine()
    {
        if (isTyping)
        {
            SkipTyping();
            return;
        }
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        var line = lines.Dequeue();
        typingRoutine = StartCoroutine(TypeLine(line));
    }

    public void SpeakStyle(Speaking speak)
    {
        if (speak == null) return;
        textBox.color = speak.dialogueColor;
        textBox.font = speak.dialogueFont;
    }
    

    public IEnumerator TypeLine(DialogueLine line)
    {
        isPlayng = true;
        isTyping = true;
        textBox.text = "";
        SpeakStyle(line.speak);
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
            ShowNextLine();
        }
        
        isPlayng = false;
    }
    

    public void SkipTyping()
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        textBox.text = textBox.text; 
        isTyping = false;
    }

    void EndDialogue()
    {
        textBox.text = "";
        nextButton.enabled = true;
    }
}
