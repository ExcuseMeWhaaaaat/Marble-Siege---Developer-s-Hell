using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEditor;


[CreateAssetMenu(fileName = "ChunkDialogue", menuName = "Scriptable Objects/ChunkDialogue")]


public class ChunkDialogue : ScriptableObject
{
    
    public List<DialogueLine> lines;
    


}

[System.Serializable]
public class DialogueLine
{
    [TextArea] public string text;

    public int correctID;
    public Speaking speak;
    public float typeDelay;
}







