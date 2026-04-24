using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject player;
    private Vector2 direction;
    void Start()
    {
        player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        Invoke(nameof(SelfDelete), 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * Time.deltaTime * 10);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void SelfDelete()
    {
        Destroy(gameObject);
    }
}
