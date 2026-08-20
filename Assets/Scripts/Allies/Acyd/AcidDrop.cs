using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] Rigidbody2D dropRb;
    [SerializeField] float speed;
    private Vector2 direction;
    [SerializeField] Color fadeColor;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    

    private void Start()
    {
        direction = new Vector2(0, -speed);
    }

    private void FixedUpdate()
    {
       dropRb.linearVelocity = direction;
       
    }

    private void Update()
    {
        fadeColor.a-=Time.deltaTime;
        spriteRenderer.color = fadeColor;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        
    }
}
