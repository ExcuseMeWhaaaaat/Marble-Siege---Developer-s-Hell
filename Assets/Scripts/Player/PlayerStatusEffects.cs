using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatusEffects : MonoBehaviour
{
    [SerializeField] private ScriptForYou playerControls;
    [SerializeField] private PlayerHeallth playerHealth;
    
    [SerializeField] float stunTime;
    [SerializeField] float chillTime;
    [SerializeField] float curifyTime;
    [SerializeField] float poisonTime;
    [SerializeField] float cureCD;
    [SerializeField] int windedTime = 30;

    [SerializeField] bool isStunned = false;
    [SerializeField] bool isChilled = false;
    [SerializeField] bool curified = false;
    [SerializeField] bool isWinded;
    [SerializeField] bool isPoisoned = false;
    public bool canCure = true;
    
    private Coroutine chillCoroutine;
    private Coroutine stunCoroutine;
    private Coroutine poisonCoroutine;

    [SerializeField] List<Color> statusEffectColors;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] TextMeshProUGUI cureText;

    private void FixedUpdate()
    {
        if (stunCoroutine != null)
        {
            playerControls.rb.linearVelocity = Vector2.zero;
        }

        if (isWinded)
        {
            playerControls.canJump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Cure":
                CurifyCure();

                

                break;
            case "NormalStun":
                if (!curified)
                {
                    isStunned = true;
                    if (stunCoroutine == null)
                    {
                        stunCoroutine = StartCoroutine(Stun());
                    }
                }
                break;
            case "NormalChill":
                if (!curified)
                {
                    isChilled = true;
                    if (chillCoroutine == null)
                    {
                        chillCoroutine = StartCoroutine(Chill());
                    }
                }
                break;
            case "Windy":
                {
                    if (isWinded) return;

                    spriteRenderer.color = statusEffectColors[3];
                    isWinded = true;
                    StartCoroutine(Winded());
                }
                break;
            case "Poison":
                {
                    PoisonCheck();
                    break;
                }
        }

        if (stunCoroutine == null)
        {
            playerControls.canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Poison":
                {
                    
                    PoisonCheck();
                    break;
                }
        }
    }

    public void PoisonCheck()
    {
        if (!curified && PlayerHeallth.playerHealth > 1)
        {
            isPoisoned = true;
            
            if (poisonCoroutine == null)
            {
                poisonCoroutine = StartCoroutine(Poison());
            }
            else
            {
                return;
            }
        }
    }

    public void Cure(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (canCure)
        {
            InstantCure();
            canCure = false;
            StartCoroutine(Cured());
            
        }
    }


    IEnumerator Stun()
    {
        
        stunTime = 3;
        while (stunTime > 0 && isStunned)
        {
            spriteRenderer.color = statusEffectColors[2];
            playerControls.speed *= 0f;
            playerControls.canJump = false;
            yield return new WaitForSeconds(1f);
            stunTime--;

        }
        playerControls.speed = 10;
        stunCoroutine = null;
        playerControls.canJump = true;
        isStunned = false;
        spriteRenderer.color = Color.white;
    }

    IEnumerator Chill()
    {
        
        chillTime = 10;
        while (chillTime > 0 && isChilled)
        {
            spriteRenderer.color = statusEffectColors[1];
            playerControls.speed--;
            yield return new WaitForSeconds(1f);
            chillTime--;

        }
        playerControls.speed =10;
        isChilled = false;
        spriteRenderer.color = Color.white;
    }
    IEnumerator Winded()
    {
        windedTime = 20;
        while (windedTime > 0)
        {

            yield return new WaitForSeconds(1f);
            windedTime--;
        }
        
        spriteRenderer.color = Color.white;
        isWinded = false;
    }
    public void GetCured()
    {
        InstantCure();
        StartCoroutine(Cured());
        canCure = false;
    }

    public void InstantCure()
    {
        playerControls.speed = 10;
        isStunned = false;
        isChilled = false;

        stunTime = 0;
        chillTime = 0;
        
    }

    public void CurifyCure()
    {
        InstantCure();
        StartCoroutine(Curify());
        canCure= false;
    }

    IEnumerator Curify()
    {
        curifyTime = 20;
        while (curifyTime > 0)
        {
            spriteRenderer.color = statusEffectColors[0];
            curified = true;
            yield return new WaitForSeconds(1f);
            curifyTime--;
            
        }
        curified = false;
        spriteRenderer.color = Color.white;
    }
    IEnumerator Cured()
    {
        cureCD = 30;
        while (cureCD > 0)
        {
            yield return new WaitForSeconds(1f);
            cureCD--;
            UpdateUI();
        }
        canCure = true;
    }
    public void UpdateUI()
    {
        if(!canCure)
        {
            cureText.text = cureCD.ToString();
        }
        else
        {
            cureText.text = "Ready";
        }
    }


    IEnumerator Poison()
    {
        poisonTime = 3;
        while (poisonTime > 0 && PlayerHeallth.playerHealth > 1)
        {
            spriteRenderer.color = statusEffectColors[4];
            PlayerHeallth.playerHealth--;
            playerHealth.UpdateHealthUI();
            yield return new WaitForSeconds(1f);
            poisonTime--;
        }
        poisonCoroutine = null;
        isPoisoned = false;
        
        spriteRenderer.color = Color.white;
    }

}
