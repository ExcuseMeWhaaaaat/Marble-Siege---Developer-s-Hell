using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] Rigidbody2D dropRb;
    [SerializeField] float speed;
    private Vector2 direction;
    [SerializeField] GameObject portal;
    private Vector2 portalDirection;

    private void Start()
    {
        direction = new Vector2(Random.Range(-2, 2), Random.Range(-3,0));
        portal = GameObject.FindGameObjectWithTag("Portal");
        portalDirection = (portal.transform.position - transform.position).normalized;
        
    }

    private void FixedUpdate()
    {
        
        if(portal != null)
        {
            dropRb.linearVelocity = portalDirection * speed;
        }
        else
        {
            dropRb.linearVelocity = direction * speed;
        }
        
    }

}
