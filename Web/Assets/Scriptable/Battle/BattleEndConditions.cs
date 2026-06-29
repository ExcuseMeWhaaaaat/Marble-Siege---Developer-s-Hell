using UnityEngine;

[CreateAssetMenu(fileName = "BattleEndConditions", menuName = "Scriptable Objects/BattleEndConditions")]
public class BattleEndConditions : ScriptableObject
{
    public bool executedAttack;
    public bool hasDamaged;
    public bool wasDamaged;
    public bool hasHealed;
}
