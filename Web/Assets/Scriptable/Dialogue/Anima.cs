using UnityEngine;

[CreateAssetMenu(fileName = "Anima", menuName = "Scriptable Objects/Anima")]
public class Anima : ScriptableObject
{
    public string characterName;           
    public AnimationClip idle;
    public AnimationClip talk;
    public AnimationClip gesture;
    
}
