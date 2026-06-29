using UnityEngine;

public class AutoDialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueChunk testChunk;
    
    [SerializeField] bool hasTriggered;
    public void CallDialogue()
    {
        if (testChunk == null || hasTriggered) return;
        DialogueManager.Instance.StartDialogue(testChunk);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CallDialogue();
            hasTriggered = true;
            
            
        }
        
    }
}
