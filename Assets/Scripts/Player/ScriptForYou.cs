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
    [SerializeField] float chillSpeedMultiplier;
    [SerializeField] bool stunnable;

    private Coroutine stunCoroutine;
    
    

    private void Start()
    {
        transform.position = spawnPoint.transform.position;
        stunnable = true;
        
    }



    private void FixedUpdate()
    {
        if(stunCoroutine != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        
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
            canJump = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        }
        


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            transform.position = spawnPoint.transform.position;
        }
        switch (collision.gameObject.tag)
        {
            case "NormalStun":
                if(stunCoroutine == null)
                {
                    stunCoroutine = StartCoroutine(Stun());
                    stunnable = false;
                }                
                break;
            case "NormalChill":
                if(speed > 5)
                {
                    StartCoroutine(Chill());
                }
                break;
        }

        
    }

    private void Update()
    {
        hit = (int)rb.linearVelocity.magnitude;
    }
    

   

    
    IEnumerator Stun()
    {
        stunTime = 3;
        while (stunTime > 0)
        {
            
            speed = 0;
            yield return new WaitForSeconds(1f);
            stunTime--;
            
        }
        speed = 10;
        stunCoroutine = null;
        stunnable = true;

    }

    IEnumerator Chill()
    {
        chillTime = 15;
        while(chillTime > 0)
        {
            speed--;
            yield return new WaitForSeconds(1f);
            chillTime--;
        }
        speed = 10;
        
    }
}
