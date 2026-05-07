using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static DialogueManager;

[CreateAssetMenu(fileName = "DialogueChunk", menuName = "Scriptable Objects/DialogueChunk")]
public class DialogueChunk : ScriptableObject
{
    
    public List<DialogueLine> lines;
    


}

[System.Serializable]
public class DialogueLine
{
    [TextArea] public string text;

    public int correctID;
    public Speaking speak;
}







