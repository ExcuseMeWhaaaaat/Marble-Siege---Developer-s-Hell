using UnityEngine;

public class AutoDialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueChunk testChunk;
    
    [SerializeField] bool hasTriggered;
    public void CallDialogue()
    {
        if (testChunk == null || hasTriggered) return;
        DialogueManagement.instance.SetChunk(testChunk);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            CallDialogue();
            
        }
        
    }
}
