using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttachDialogue : MonoBehaviour
{

    
     [SerializeField] private DialogueChunk testChunk;
     

    public void TriggerDialogue()
    {
        if (DialogueManagement.instance.isTyping) return;
        if(DialogueManagement.instance.messageIndex > 0)
        {
            DialogueManagement.instance.MoveToNext();
        }
        else
        {
            DialogueManagement.instance.SetChunk(testChunk);
            
            Debug.Log(testChunk);
        }
            
        
    }
}
