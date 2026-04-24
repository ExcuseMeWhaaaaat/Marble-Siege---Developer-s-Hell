using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueChunk", menuName = "Scriptable Objects/DialogueChunk")]
public class DialogueChunk : ScriptableObject
{
    public bool revealNames = false;   
    public List<DialogueLine> lines;
    public List<AnimEvent> animEvents;
    public Vector2 textOffeset;
    
    
}

[System.Serializable]
public class DialogueLine
{
    [TextArea] public string text;
    public Speaking speak;
    public float typingSpeed = 0.05f;
    public float typingDelay;
    public int charIDRequirement;

}

[System.Serializable]
public class AnimEvent
{
    
    public List<AnimationClip> clipList;
}


