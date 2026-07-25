using UnityEngine;

[CreateAssetMenu(fileName = "BattleCondition", menuName = "Scriptable Objects/BattleCondition")]
public abstract class BattleContext1 : ScriptableObject
{
    public abstract bool IsMet(BattleContext2 context);
    

}
