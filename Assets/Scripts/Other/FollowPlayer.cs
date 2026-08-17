using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    

    [SerializeField] private GameObject player;
    [SerializeField] float speed;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        
        if (player != null)
        {
            transform.position = player.transform.position;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    
}
