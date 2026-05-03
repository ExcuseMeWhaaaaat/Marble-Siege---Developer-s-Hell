using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] Rigidbody2D dropRb;
    [SerializeField] float speed;
    private Vector2 direction;
    

    private void Start()
    {
        direction = new Vector2(Random.Range(-2, 2), Random.Range(-3,0));
    }

    private void FixedUpdate()
    {
        dropRb.linearVelocity = direction * speed;
        
    }

}
