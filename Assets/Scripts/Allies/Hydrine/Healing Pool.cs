using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class HealingPool : MonoBehaviour
{
    
    [SerializeField] int interval;
    [SerializeField] int secondsLeft;
    [SerializeField] private PlayerHeallth playerHP;

    private void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHeallth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExecuteAbility();
        }
        
    }

    public void ExecuteAbility()
    {
        if (playerHP == null) return;
        
        StartCoroutine(GenerateHealPool());
        
    }

    IEnumerator GenerateHealPool()
    {

        secondsLeft = 5;
        while (secondsLeft > 0)
        {
            yield return new WaitForSeconds(interval);
            Debug.Log("Before");
            if(playerHP.playerHealth < playerHP.maxPlayerHealth)
            {
                playerHP.playerHealth++;
            }
            playerHP.UpdateHealthUI();
            Debug.Log("After");
            secondsLeft--;
            
           
        }
        
    }
    
}
