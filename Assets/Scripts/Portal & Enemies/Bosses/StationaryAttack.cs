using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StationaryAttack : BossAttack
{
    
    [SerializeField] Transform bRPos;
    [SerializeField] Transform tLPos;
    [SerializeField] List<GameObject> warning;
    

    public override void Execute()
    {
        
    }

    

    private Vector2 SpawnAtPos()
    {
        float xPos = Random.Range(tLPos.position.x, bRPos.position.x);
        float yPos = Random.Range(tLPos.position.y, bRPos.position.y);
        Vector2 spawnPos = new Vector2(xPos, yPos);
        return spawnPos;
    }

    public void Warn()
    {
        int spawnIndex = Random.Range(0, warning.Count);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(warning[spawnIndex], SpawnAtPos(), transform.rotation);
        }
        
        
    }
}
