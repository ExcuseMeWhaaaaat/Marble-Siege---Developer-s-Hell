using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WindCharging : MonoBehaviour
{
    
    [SerializeField] float chargeSpeed;
    private Vector2 direction;
    private float enemyDistance;
    [SerializeField] Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerRb == null) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb.AddForce(direction * chargeSpeed, ForceMode2D.Force);
        }
    }

    private void Update()
    {
        direction = playerRb.linearVelocity;
    }
}
