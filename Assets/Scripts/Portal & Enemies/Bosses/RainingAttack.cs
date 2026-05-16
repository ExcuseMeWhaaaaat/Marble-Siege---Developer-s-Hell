using System.Collections;
using UnityEngine;

public class RainingAttack : BossAttack
{
    
    [SerializeField] Vector2 startPos;
    [SerializeField] float spawnRange;
    private bool isActive;
    [SerializeField] GameObject projectile;
    [SerializeField] float attackPeriod;
    [SerializeField] float attackPeriodSeconds;
    
    

    

    public override void Execute()
    {
        
        isActive = true;
        StartCoroutine(ExecutionCoroutine());
        PromptDialogue();
    }
    public void SpawnProjectile()
    {
            Instantiate(projectile, SpawnProjectilePos(), transform.rotation);
        


    }
    public Vector2 SpawnProjectilePos()
    {
        Vector2 spawnPos = new Vector2(startPos.x + Random.Range(-spawnRange, spawnRange), startPos.y);
        return spawnPos;
    }

    IEnumerator ExecutionCoroutine()
    {
        attackPeriodSeconds = attackPeriod;
        while (attackPeriodSeconds > 0)
        {
            yield return new WaitForSeconds(0.5f);
            SpawnProjectile();
            attackPeriodSeconds--;
        }
        isActive = false;
        
    }

    public void PromptDialogue()
    {
        if (ScriptedTutorial.instance == null) return;
        ScriptedTutorial.instance.CompleteEvent(ScriptedTutorial.TutorialEvents.UseMe, 3);
    }
}
