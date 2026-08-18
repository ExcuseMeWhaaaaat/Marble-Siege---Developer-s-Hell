using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class HealingPool : MonoBehaviour
{
    
    [SerializeField] int interval;
    [SerializeField] int secondsLeft;
    [SerializeField] private PlayerHeallth playerHP;
    private Coroutine healingCoroutine;

    private void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHeallth>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExecuteAbility();
        }
        
    }

    public void ExecuteAbility()
    {
        if(healingCoroutine == null)
        {
            healingCoroutine = StartCoroutine(GenerateHealPool());
        }
       
        
    }

    IEnumerator GenerateHealPool()
    {

        secondsLeft = 3;
        while (secondsLeft > 0 && PlayerHeallth.playerHealth < playerHP.maxPlayerHealth)
        {
            yield return new WaitForSeconds(interval);
            PlayerHeallth.playerHealth++;
            secondsLeft--;
            playerHP.UpdateHealthUI();
           
        }
        healingCoroutine = null;
        
    }
    
}
