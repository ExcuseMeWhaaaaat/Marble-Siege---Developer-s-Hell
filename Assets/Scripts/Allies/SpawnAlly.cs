
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAlly : MonoBehaviour
{
    
    
    [SerializeField] Transform spawnPos;
    [SerializeField] float cooldownTime;
    public bool isOnCooldown = false;
    
    [SerializeField] List<GameObject> ability = new List<GameObject>();
    [SerializeField] Image allyHead;
    [SerializeField] TextMeshProUGUI allyCooldownText;
    [SerializeField] Color cooldownColor;
    [SerializeField] GameObject portal;

    private void Start()
    {
        allyHead.color = Color.white;
        allyCooldownText.text = "Ready";
    }
    public void Ability()
    {
        if (GameManagement.instance.currentState == GameManagement.GameStates.Paused) return;
        if (!isOnCooldown && portal !=null)
        {
            Conditions(0);
            
        }
        else
        {
            
            Debug.Log("This character is on cooldown");
        }
    }
    public void Ability2()
    {
        if (GameManagement.instance.currentState == GameManagement.GameStates.Paused) return;
        if (!isOnCooldown && portal != null)
        {

            Conditions(1);
        }
        else
        {
            Debug.Log("This character is on cooldown");
        }


    }
    public IEnumerator AllyCooldown()
    {
        cooldownTime = 150;
        
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

    public void Conditions(int indexAbility)
    {
        
        Instantiate(ability[indexAbility], spawnPos.position, transform.rotation);
        isOnCooldown = true;
        StartCoroutine (AllyCooldown());
    }


}
