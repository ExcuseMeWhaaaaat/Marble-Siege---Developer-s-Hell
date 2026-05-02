
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAlly : MonoBehaviour
{
    
    
    [SerializeField] Vector2 spawnPos;
    [SerializeField] float cooldownTime;
    public bool isOnCooldown = false;
    
    [SerializeField] List<GameObject> ability = new List<GameObject>();
    [SerializeField] Image allyHead;
    [SerializeField] TextMeshProUGUI allyCooldownText;
    [SerializeField] Color cooldownColor;


    private void Start()
    {
        allyHead.color = Color.white;
        allyCooldownText.text = "Ready";
    }
    public void Ability()
    {
        if (!isOnCooldown)
        {
            Instantiate(ability[0], spawnPos, transform.rotation);
            Debug.Log("Spawned");
            isOnCooldown = true;
            StartCoroutine(AllyCooldown());
            
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
            isOnCooldown = true;
            StartCoroutine(AllyCooldown());
            
        }
        else
        {
            Debug.Log("This character is on cooldown");
        }


    }
    IEnumerator AllyCooldown()
    {
        cooldownTime = 90;
        
        while (cooldownTime > 0 && isOnCooldown)
        {
            allyHead.color = Color.clear;
            yield return new WaitForSeconds(1f);
            cooldownTime--;
            allyCooldownText.text = cooldownTime.ToString();
            
        }
        allyHead.color = Color.white;
        allyCooldownText.text = "Ready";
        isOnCooldown = false;
        
    }
}
