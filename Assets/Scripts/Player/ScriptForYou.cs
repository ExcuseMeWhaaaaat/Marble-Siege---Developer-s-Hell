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
    
    
    
    

    private void Start()
    {
        transform.position = spawnPoint.transform.position;
        
    }



    private void FixedUpdate()
    {
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


    private void Update()
    {
        if (transform.position.y < -outOfBoundsY || transform.position.y > outOfBoundsY || transform.position.x < -outOfBOundsX || transform.position.x > outOfBOundsX)
        {
            transform.position = spawnPoint.transform.position;
            rb.linearVelocity = Vector2.zero;
        }
        hit = (int)rb.linearVelocity.magnitude;
        
    }

    
}
