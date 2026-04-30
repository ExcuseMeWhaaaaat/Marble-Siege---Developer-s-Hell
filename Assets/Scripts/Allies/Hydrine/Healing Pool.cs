using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class HealingPool : AllyExecute
{
    
    [SerializeField] int interval;
    [SerializeField] int secondsLeft;
    [SerializeField] private PlayerHeallth playerHP;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject.CompareTag("Player"))
        ExecuteAbility();
    }

    public override void ExecuteAbility()
    {
        StartCoroutine(GenerateHealPool());
    }

    IEnumerator GenerateHealPool()
    {
        secondsLeft = 5;
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(interval);
            secondsLeft--;
            playerHP.playerHealth++;
        }
        Destroy(gameObject);
    }
    
}
