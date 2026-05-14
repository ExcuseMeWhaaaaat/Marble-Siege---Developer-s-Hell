using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatusEffects : MonoBehaviour
{
    [SerializeField] private ScriptForYou playerControls;
    
    [SerializeField] float stunTime;
    [SerializeField] float chillTime;
    [SerializeField] float curifyTime;
    [SerializeField] float cureCD;
    
    [SerializeField] bool isStunned = false;
    [SerializeField] bool isChilled = false;
    [SerializeField] bool curified = false;
    public bool canCure = true;
    
    private Coroutine chillCoroutine;
    private Coroutine stunCoroutine;

    [SerializeField] Color curifiedColor;
    [SerializeField] Color chilledColor;
    [SerializeField] Color stunColor;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] TextMeshProUGUI cureText;

    private void FixedUpdate()
    {
        if (stunCoroutine != null)
        {
            playerControls.rb.linearVelocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Cure":
                CurifyCure();

                Debug.Log("Cured!");

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
        }

        if (stunCoroutine == null)
        {
            playerControls.canJump = true;
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
            spriteRenderer.color = stunColor;
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
            spriteRenderer.color = chilledColor;
            playerControls.speed--;
            yield return new WaitForSeconds(1f);
            chillTime--;

        }
        playerControls.speed =10;
        isChilled = false;
        spriteRenderer.color = Color.white;
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
            spriteRenderer.color = curifiedColor;
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
}
