using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHeallth : MonoBehaviour
{
    public int playerHealth;
    public TextMeshProUGUI hpIndicator;
    private bool isInvincible;
    [SerializeField] int invinciblityFrames;
    public TextMeshProUGUI healCDFramesInd;
    [SerializeField] int healBy;
    public int maxPlayerHealth;
    [SerializeField] int healCooldownFrames;
    private bool canHeal = true;
    
    
    private SkillPoints skillPoints;
    [SerializeField] GameObject portal;
    [SerializeField] Color invincColor;
    [SerializeField] Color defColor;
    [SerializeField] SpriteRenderer spriteColor;
    [SerializeField] GameObject healingImage;
    [SerializeField] string statusEffect;
    
    private bool isElimated;

    

    private void Start()
    {
        
        
        if (!skillPoints)
        {
            skillPoints = GetComponent<SkillPoints>();
        }
        UpdateHealthUI();
        healCDFramesInd.text = healCooldownFrames.ToString();

    }
    public void Eliminate()
    {
        if (isElimated) return;
        isElimated = true;
        Destroy(gameObject);
        skillPoints.skillPoints = 0;
        SoundManagement.PlaySound(SoundType.Fail, 0.75f);
    }

    public void Heal(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        if (playerHealth < maxPlayerHealth && portal !=null)
        {
            if (canHeal)
            {
                
                playerHealth++;
                UpdateHealthUI();
                ActivateHealCooldown();
                if(SoundManagement.instance != null)
                SoundManagement.PlaySound(SoundType.Heal, 0.75f);
            }
            
        }
        
    }

    

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "NormalAttack":
                CheckForHealth(1);
                break;
            case "HeavyAttack":
                CheckForHealth(3);
                break;
            case "PowerfuLAttack":
                CheckForHealth(6);break;
            case "Cure":
                statusEffect = "";
                break;
        }
    }

    public void ActivateInvincibility()
    {
        isInvincible = true;
        StartCoroutine(Invinciblity());
    }

    public void ActivateHealCooldown()
    {
        canHeal = false;
        
        healingImage.SetActive(false);
        StartCoroutine(HealCooldown());
    }

    IEnumerator Invinciblity()
    {
        invinciblityFrames = 5;
        while (invinciblityFrames > 0)
        {
            yield return new WaitForSeconds(1);
            invinciblityFrames--;
            
        }
        if (invinciblityFrames < 1)
        {
            isInvincible = false;
        }
        spriteColor.color = defColor;
    }

    public void CheckForHealth(int damageTaken)
    {
        
        if (!isInvincible)
        {
            if(SoundManagement.instance != null)
            {
                SoundManagement.PlaySound(SoundType.Hurt, 0.75f);
            }
            
            playerHealth -= damageTaken;
            ActivateInvincibility();
            if(skillPoints != null)
            {
                skillPoints.FillMeter(2);
            }
            
            if (spriteColor != null)
            {
                spriteColor.color = invincColor;
            }
            
        }
        UpdateHealthUI();
        if (playerHealth < 1)
        
            Eliminate();
    }

    public void UpdateHealthUI()
    {

        if (hpIndicator == null) return;
        hpIndicator.text = playerHealth.ToString();
    }

    IEnumerator HealCooldown()
    {
        healCooldownFrames = 45;
        while (healCooldownFrames > 0)
        {
            yield return new WaitForSeconds(1);
            healCooldownFrames--;
            healCDFramesInd.text = healCooldownFrames.ToString();
            
        }
        canHeal = true;
        healingImage.SetActive(true);
        healCDFramesInd.text = "";

    }

    
    
}
