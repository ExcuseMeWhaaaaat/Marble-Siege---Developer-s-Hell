using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ScriptForYou : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float outOfBoundsY;
    [SerializeField] float outOfBOundsX;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float speed;
    private Vector2 movement;
    public float hit;
    private float horizontal;
    [SerializeField] bool canJump = false;

    
    [SerializeField] float stunTime;
    [SerializeField] float chillTime;
    [SerializeField] float curifyTime;

    [SerializeField] bool isStunned = false;
    [SerializeField] bool isChilled = false;
    [SerializeField] bool curified = false;

    private Coroutine chillCoroutine;
    private Coroutine stunCoroutine;

    [SerializeField] Color curifiedColor;
    [SerializeField] Color chilledColor;
    [SerializeField] Color stunColor;
    [SerializeField] SpriteRenderer spriteRenderer;
    public string statusEffect;
    [SerializeField] bool windCharged;
    
    
    
    private void Start()
    {
        if(spawnPoint != null)
        transform.position = spawnPoint.transform.position;
        
        
    }



    private void FixedUpdate()
    {
        
        if(stunCoroutine != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        
        if (windCharged)
        {
            rb.linearVelocity = new Vector2(horizontal * speed * 3,rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }
            
    }

    public void Movement(InputAction.CallbackContext context)
    {
        
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        if (canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
            canJump = false;
        }
        


    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindCharge"))
        {
            windCharged = true;
            Debug.Log("Wind Charge Used!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindCharge"))
        {
            windCharged = false;
            Debug.Log("Charge Exited");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            transform.position = spawnPoint.transform.position;
        }
        
        switch (collision.gameObject.tag)
        {
            case "Cure":
                GetCured();
                
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
        
        if(stunCoroutine == null)
        {
            canJump = true;
        }

    }

    

    private void Update()
    {
        hit = (int)rb.linearVelocity.magnitude;
    }

    
   

    
    IEnumerator Stun()
    {
        stunTime = 3;
        while (stunTime > 0 && isStunned)
        {
            spriteRenderer.color = stunColor;
            speed *= 0f;
            canJump = false;
            yield return new WaitForSeconds(1f);
            stunTime--;
            
        }
        speed = 10;
        stunCoroutine = null;
        canJump = true;
        isStunned = false;
        spriteRenderer.color = Color.white;
    }

    IEnumerator Chill()
    {
        
        chillTime = 10;
        while(chillTime > 0 && isChilled)
        {
            spriteRenderer.color = chilledColor;
            speed--;
            yield return new WaitForSeconds(1f);
            chillTime--;
            
        }
        speed++;
        isChilled=false;
        spriteRenderer.color = Color.white;
    }

    public void GetCured()
    {
        speed = 10;
        isStunned = false;
        isChilled = false;
        
        stunTime = 0;
        chillTime = 0;
        StartCoroutine(Curify());
        
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
}
