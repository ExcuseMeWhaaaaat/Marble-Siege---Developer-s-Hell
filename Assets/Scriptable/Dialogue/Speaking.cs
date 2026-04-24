using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "Speaking", menuName = "Scriptable Objects/Speaking")]
public class Speaking : ScriptableObject
{
    [TextArea] public string displayName;
    public Color dialogueColor;
    public TMP_FontAsset dialogueFont;
    public Color dialogueOutlineColor;
    
    
    //public float camShiftSpeed;
}


