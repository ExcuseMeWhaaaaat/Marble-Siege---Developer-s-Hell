using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public DialogueChunk chunk;

    public void Trigger()
    {
        DialogueManager.Instance.StartDialogue(chunk);
    }
}
