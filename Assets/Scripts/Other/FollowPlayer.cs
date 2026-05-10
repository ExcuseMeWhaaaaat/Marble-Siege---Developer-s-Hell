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
            Vector2 direction = player.transform.position - transform.position;
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
