using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossAttackSelection", menuName = "Scriptable Objects/BossAttackSelection")]
public class BossAttackSelection : ScriptableObject
{
    public List<BossAttack> attackSelection = new List<BossAttack>();
    public List<int> hpTriggers = new List<int>();
    public List<AnimationClip> animations = new List<AnimationClip>();
    public AnimationClip idleAnim;
    
}
