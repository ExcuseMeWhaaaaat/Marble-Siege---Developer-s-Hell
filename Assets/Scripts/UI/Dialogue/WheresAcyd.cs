using UnityEngine;

public class WheresAcyd : MonoBehaviour
{
    
    public void AcydIsntHere()
    {
        if (ScriptedTutorial.instance == null || DialogueManagement.Instance.isTyping) return;
        ScriptedTutorial.instance.CompleteEvent(ScriptedTutorial.TutorialEvents.Acyd, 3);
        
    }

}
