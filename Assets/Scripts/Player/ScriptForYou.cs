using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ScriptForYou : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float outOfBoundsY;
    [SerializeField] float outOfBOundsX;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] bool canBoost = true;
    [SerializeField] float boostTime;
    [SerializeField] float boostCooldown;

    public float speed;
    private Vector2 movement;
    public float hit;
    private float horizontal;
    public bool canJump = false;
    public float dmgMultiplier;
    
    
    public string statusEffect;
    [SerializeField] bool windCharged;

    [SerializeField] TextMeshProUGUI mbText;
    [SerializeField] TextMeshProUGUI mbDMG;
    
    private void Start()
    {
        if(spawnPoint != null)
        transform.position = spawnPoint.transform.position;
    }



    private void FixedUpdate()
    {
        
        
        
        if (windCharged)
        {
            rb.linearVelocity = new Vector2(horizontal * speed * 2,rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }

        if(transform.position.x > outOfBOundsX || transform.position.x < -outOfBOundsX || transform.position.y > outOfBoundsY)
        {
            transform.position = spawnPoint.transform.position;
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

    public void Boost(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (canBoost)
        {
            dmgMultiplier++;
            canBoost = false;
            StartCoroutine(MoraleBoost());
            StartCoroutine(MBCooldown());
            Debug.Log(canBoost);
            
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
    

    IEnumerator MoraleBoost()
    {
        boostTime = 15;
        while(boostTime > 0)
        {
            yield return new WaitForSeconds(1f);
            boostTime--;
            UpdateUI();
        }
        dmgMultiplier--;
        
    }

    IEnumerator MBCooldown()
    {
        boostCooldown = 60;
        while (boostCooldown > 0)
        {
            yield return new WaitForSeconds(1f);
            boostCooldown--;
            UpdateUI();
        }
        canBoost = true;
    }

    private void Update()
    {
        hit = (int)rb.linearVelocity.magnitude * dmgMultiplier;
    }


    public void UpdateUI()
    {
        
        if (!canBoost)
        {
            mbText.text = boostCooldown.ToString();
            mbDMG.text = dmgMultiplier.ToString();
        }
        else
        {
            mbText.text = "Ready";
        }
    }



}
