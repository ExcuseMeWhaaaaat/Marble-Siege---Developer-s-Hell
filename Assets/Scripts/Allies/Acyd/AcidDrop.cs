using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] Rigidbody2D dropRb;
    [SerializeField] float speed;
    private Vector2 direction;
    private Color fadeColor;
    

    private void Start()
    {
        direction = new Vector2(0,-speed);
        
        
    }

    private void FixedUpdate()
    {
       dropRb.linearVelocity = direction * speed;
        
    }

    private void Update()
    {
        fadeColor.a--;
    }
}
