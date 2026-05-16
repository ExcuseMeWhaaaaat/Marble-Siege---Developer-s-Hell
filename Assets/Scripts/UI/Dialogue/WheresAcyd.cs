using UnityEngine;

public class WheresAcyd : MonoBehaviour
{
    [SerializeField] private SpawnAlly spawnAlly;
    public void AcydIsntHere()
    {
        if (ScriptedTutorial.instance == null || DialogueManager.Instance.isTyping) return;
        ScriptedTutorial.instance.CompleteEvent(ScriptedTutorial.TutorialEvents.Acyd, 4);
    }
}
