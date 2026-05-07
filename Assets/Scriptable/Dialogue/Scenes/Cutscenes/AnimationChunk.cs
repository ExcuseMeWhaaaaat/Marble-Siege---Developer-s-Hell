using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationChunk", menuName = "Scriptable Objects/AnimationChunk")]
public class AnimationChunk : ScriptableObject
{
    
    
    [System.Serializable]
    public class AnimationCommand
    {
        public string animationState;
        public int animID;
    }
}
