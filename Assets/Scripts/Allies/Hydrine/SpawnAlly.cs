using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlly : MonoBehaviour
{
    
    
    [SerializeField] Vector2 spawnPos;
    [SerializeField] float cooldownTime;
    public bool isOnCooldown = false;
    
    [SerializeField] List<GameObject> ability = new List<GameObject>();

    
    

    public void Ability()
    {
        if (!isOnCooldown)
        {
            Instantiate(ability[0], spawnPos, transform.rotation);
            Debug.Log("Spawned");
            StartCoroutine(AllyCooldown());
            isOnCooldown = true;
        }
        else
        {
            Debug.Log("This character is on cooldown");
        }
    }
    public void Ability2()
    {
        if (!isOnCooldown)
        {
            Instantiate(ability[1],spawnPos,transform.rotation);
            Debug.Log("Instantiated");
            StartCoroutine(AllyCooldown());
            isOnCooldown = true;
        }
        else
        {
            Debug.Log("This character is on cooldown");
        }


    }

    IEnumerator AllyCooldown()
    {
        cooldownTime = 5;
        while(cooldownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            cooldownTime--;
        }
        isOnCooldown = false;
    }
}
