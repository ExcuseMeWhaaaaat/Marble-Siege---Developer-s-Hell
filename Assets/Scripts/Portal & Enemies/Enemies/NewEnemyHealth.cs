using System.Runtime.CompilerServices;
using TMPro;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;

    [SerializeField] private GameObject player;
    private ScriptForYou scriptYou;
    public float attackRange;

    [SerializeField] private Transform canvasTransform;
    [SerializeField] TextMeshProUGUI dmgText;
    private Camera cam;
    private TextMeshProUGUI newText;
    private SkillPoints skillPoints;
    public float enemyDistance;
    private Signal signal;
    private bool isDead;


    void Start()
    {

        if (!canvasTransform)
        {
            canvasTransform = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Transform>();
        }
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player)
            {
                enabled = false;
                return;
            }

        }
        
        if (!EnemyCounting.instance)
        {
            enabled = false;
            return;

        }
        scriptYou = player.GetComponent<ScriptForYou>();
        skillPoints = player.GetComponent<SkillPoints>();
        if (!cam)
        {
            cam = Camera.main;
            if (!cam)
            {
                enabled = false;
                return;
            }
        }

        signal = GetComponentInChildren<Signal>();
        if (!scriptYou || !skillPoints)
        {
            enabled = false;
            return;
        }
        
    }


    void Update()
    {
        
        
        if (signal.spriteColorChange != null)
        {
            if (enemyDistance < attackRange)
            {
                signal.spriteColorChange.color = signal.signalColor;
            }
            else
            {
                signal.spriteColorChange.color = signal.noSignalColor;
            }
        }
    }

    public void EnemyDefeat()
    {
        if (isDead) return;
        
        
        Destroy(gameObject);
        isDead = true;

    }

    

    public void UpdateUI()
    {
        newText = Instantiate(dmgText, canvasTransform);
        newText.transform.SetParent(canvasTransform, true);
        newText.rectTransform.position = cam.WorldToScreenPoint(transform.position);
        newText.text = enemyHealth.ToString();
        Destroy(newText.gameObject, 10f);

    }


    public void OnDestroy()
    {
        if (EnemyCounting.instance != null)
        {
            EnemyCounting.instance.enemyCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D acidRb;
        acidRb = collision.GetComponent<Rigidbody2D>();
        switch (collision.gameObject.tag)
        {
            case "Player":
                {
                    enemyHealth -= Mathf.RoundToInt(scriptYou.hit);
                    UpdateUI();
                    SeeEnemyDefeat();
                    break;
                }
            case "AcydAttack":
                {
                    if (acidRb == null) return;
                    enemyHealth -= (int)acidRb.linearVelocity.magnitude;
                    SeeEnemyDefeat();
                    break;
                }
            case "Radiation":
                enemyHealth -= Mathf.RoundToInt(scriptYou.hit);
                SeeEnemyDefeat();
                Debug.Log("Poison?");
                break;
            
        }
        
    }

    

    public void SeeEnemyDefeat()
    {
        if (enemyHealth < 1)
        {
            EnemyDefeat();
        }
    }
}

