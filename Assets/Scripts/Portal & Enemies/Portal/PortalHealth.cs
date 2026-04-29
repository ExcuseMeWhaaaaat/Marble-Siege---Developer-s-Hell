using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortalHealth : MonoBehaviour
{
    public int portalHP;
    public TextMeshProUGUI portalHPText;
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
    public bool wasDamaged;
    [SerializeField] string battleTarget;

    private void Start()
    {
        portalHPSldier.maxValue = maxValue;
        portalHPSldier.value = portalHP;
        if(!skillPoints || !playerControls)
        {
            playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptForYou>();
            skillPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<SkillPoints>();
        }

        portalHPText.text = battleTarget + ": " + portalHP.ToString();
        wasDamaged = false;
        
    }
    private void Update()
    {
        float playerDist = Vector2.Distance(transform.position,player.transform.position);
        if(spriteRenderer != null)
        {
            if (playerDist < attackRange)
            {
                spriteRenderer.color = activeColor;
            }
            else
            {
                spriteRenderer.color=inactiveColor;
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player") && EnemyCounting.instance.enemyCount < 1)
        {
            
            if(gameObject.tag != "Preboss")
            {
                int dmg = (int)playerControls.hit;
                portalHP -= dmg;

                if (skillPoints != null)
                {
                    skillPoints.addSkillPoints((int)dmg / 6);
                    skillPoints.FillMeter((int)dmg / 6);
                }
            }
            else
            {
                if (ConditionManagement.instance != null)
                {
                    ConditionManagement.CheckConditions(ConditionManagement.ConditionsToMeet.EnemyDamaged);
                }
            }
            
            if (SoundManagement.instance != null)
            {
                SoundManagement.PlaySound(SoundType.Damage, 0.75f);
            }

            TeleportPlayer();
            UpdateUI();
            Debug.Log("Damaged!");
            if (portalHP < 1)

                DestroyPortal();
            wasDamaged = true;
        }
    }

    

    public void TeleportPlayer()
    {
        player.transform.position = spawnPoint.transform.position;
    }
    
    public void UpdateUI()
    {
        if (portalHPText == null || portalHPSldier == null) return;
        portalHPText.text = battleTarget + ": " + portalHP.ToString();
        portalHPSldier.value = portalHP;
    }

    public void DestroyPortal()
    {
        //New
        if (isDestroyed) return;
        isDestroyed = true;
        Destroy(gameObject);
        if(skillPoints != null && SoundManagement.instance != null)
        {
            skillPoints.addSkillPoints(portalHP / 3);
            SoundManagement.PlaySound(SoundType.Success, 0.75f);
        }
        
    }

    
}
