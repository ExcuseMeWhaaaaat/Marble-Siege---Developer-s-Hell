using UnityEngine;

[CreateAssetMenu(fileName = "BattleCondition", menuName = "Scriptable Objects/BattleCondition")]
public abstract class BattleCondition : ScriptableObject
{
    public abstract bool IsMet(BattleContext2 context);
    

}
