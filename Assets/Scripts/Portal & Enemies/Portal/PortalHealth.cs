using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortalHealth : MonoBehaviour
{
    public int portalHP;
    public TextMeshProUGUI portalHPText;
    public TextMeshProUGUI bossNameText;
    [SerializeField] GameObject spawnPoint;
    
    [SerializeField] int pointVal;
    private SkillPoints skillPoints;
    private bool isDestroyed;
    [SerializeField] GameObject player;
    private ScriptForYou playerControls;
    [SerializeField] float attackRange;
    [SerializeField] Slider portalHPSldier;
    [SerializeField] float maxValue;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color activeColor;
    [SerializeField] Color inactiveColor;
    
    [SerializeField] string battleTarget;

    [SerializeField] private BossController bossController;
    [SerializeField] Button nextButton;

    

    private void Start()
    {
        if(portalHPSldier != null)
        {
            portalHPSldier.maxValue = maxValue;
            portalHPSldier.value = portalHP;
        }
        
        if(!skillPoints || !playerControls)
        {
            playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptForYou>();
            skillPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<SkillPoints>();
        }

        portalHPText.text = "Health: " + portalHP.ToString();
        bossNameText.text = battleTarget;
        
    }
    private void Update()
    {
        if(player != null)
        {
            float playerDist = Vector2.Distance(transform.position, player.transform.position);
            if (spriteRenderer != null)
            {
                if (playerDist < attackRange)
                {
                    spriteRenderer.color = activeColor;
                }
                else
                {
                    spriteRenderer.color = inactiveColor;
                }
            }
        }
        
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Rigidbody2D acidRb;
        acidRb = collision.GetComponent<Rigidbody2D>();

        
        
        switch (collision.gameObject.tag)
        {

            case "Player":
                
                int dmg = (int)playerControls.hit;

                if (EnemyCounting.instance.enemyCount < 1)
                {
                    portalHP -= dmg;
                    
                    TeleportPlayer();
                }
                if (skillPoints != null)
                {
                    skillPoints.addSkillPoints((int)dmg / 6);
                    
                }


                if (SoundManagement.instance != null)
                {
                    SoundManagement.PlaySound(SoundType.Damage, 0.75f);
                }

                



                UpdateUI();
                break;
            case "Radiation":
                {
                    portalHP -= Mathf.RoundToInt(playerControls.hit);
                    UpdateUI();
                    break;
                    
                }
            case "AcydAttack":
                {
                    
                    if (acidRb == null) return;
                    portalHP -= (int)acidRb.linearVelocity.magnitude;
                    
                    UpdateUI();
                    break;
                }
                

        }
        if (portalHP < 1)
        {
            if (ScriptedTutorial.instance != null)
            {
                ScriptedTutorial.instance.fightEnded = true;
                ScriptedTutorial.instance.SetDelay();
            }
            DestroyPortal();
        }
        PowerfulAttackCondition();
            
       
    }

    public void PowerfulAttackCondition()
    {
        if (bossController == null) return;
        
        if (bossController.powerfulAttackIndex >= 0 && bossController.powerfulAttackIndex < bossController.powerfulObjects.Count)
        {
            foreach (var powerfulObject in bossController.powerfulObjects)
            {
                if (powerfulObject == null) return;
                
                if (portalHP < bossController.hpThresholds[bossController.powerfulAttackIndex])
                {
                    bossController.usingPowerful = true;
                    bossController.SummonPowerfulAttack();
                    
                }

            }
        }

    }

    public void TeleportPlayer()
    {
        player.transform.position = spawnPoint.transform.position;
        
    }
    
    public void UpdateUI()
    {
        if (portalHPText == null || portalHPSldier == null) return;
        portalHPText.text = "Health: " + portalHP.ToString();
        portalHPSldier.value = portalHP;
    }

    public void DestroyPortal()
    {
        //New
        if (isDestroyed) return;
        isDestroyed = true;
        if(nextButton!= null)
        {
            nextButton.gameObject.SetActive(true);
        }
        Destroy(gameObject);
        
        SoundManagement.PlaySound(SoundType.Success, 0.75f);
        
        
        

    }

    
    
}
