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
        Vector2 direction = player.transform.position - transform.position;
        if (player != null)
        {
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
}
