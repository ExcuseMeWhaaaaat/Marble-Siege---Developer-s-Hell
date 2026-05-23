using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Speaking", menuName = "Scriptable Objects/Speaking")]
public class Speaking : ScriptableObject
{
    [TextArea] public string displayName;
    public Color dialogueColor;
    public TMP_FontAsset dialogueFont;
    public Color outlineColor;
    public AudioClip speakerVoice;
    
    
    
    
    
    
}


