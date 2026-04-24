using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttachConditions : MonoBehaviour
{
    [SerializeField] List<BattleCondition> battleEndConditions;
    public BattleContext2 battleContext;
    
    [SerializeField] private PortalHealth bossHP;
    

    private void Awake()
    {
        battleContext = new BattleContext2
        {
            bossHP = bossHP,
            
        };



    }
    private void Update()
    {
        foreach(var condition in battleEndConditions)
        {
            if (!condition.IsMet(battleContext))
            return;
        }
        

    }

}
