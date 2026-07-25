using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract  class BossAttack : MonoBehaviour
{
    public abstract void Execute();

    public AnimationClip animClip;
    
}
