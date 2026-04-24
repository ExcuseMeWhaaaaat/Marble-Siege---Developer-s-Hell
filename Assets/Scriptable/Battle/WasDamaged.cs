using UnityEngine;

[CreateAssetMenu(fileName = "WasDamaged", menuName = "Scriptable Objects/WasDamaged")]
public class WasDamaged : BattleCondition
{
    public override bool IsMet(BattleContext2 context)
    {
        
        return context.bossHP.wasDamaged;
    }
}
