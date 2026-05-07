using System.Collections.Generic;
using UnityEngine;
using static AnimationChunk;

[CreateAssetMenu(fileName = "CutsceneData", menuName = "Scriptable Objects/CutsceneData")]
public class CutsceneSteps : ScriptableObject
{
    [System.Serializable]
    public class CutsceneStep
    {
        
        public List<AnimationCommand> animationChunks;
    }

    public List<CutsceneStep> steps;
}
