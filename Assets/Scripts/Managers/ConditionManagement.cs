using System;
using UnityEngine;

public class ConditionManagement : MonoBehaviour
{
    public enum ConditionsToMeet
    {
        AbilityUsed,
        AllySummoned,
        EnemyDamaged,
        ObstacleBroken,
    }

    public static ConditionManagement instance;
    public bool[] conditionMet;
    public int conditionsNeeded;
    public bool battleComplete;
    public int conditionsAlreadyMet;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Start()
    {
        conditionsNeeded = conditionMet.Length;
    }

    public static void CheckConditions(ConditionsToMeet condition)
    {

        //If the condition index is greater than the number of conditions
        
        if ((int)condition >= instance.conditionMet.Length) return;

        instance.conditionMet[(int)condition] = true;
        instance.conditionsAlreadyMet++;

       

        if(instance.conditionsAlreadyMet >= instance.conditionsNeeded)
        {
            instance.battleComplete = true;
        }
        else
        {
            instance.battleComplete = false;
        }

        
        
    }
}
