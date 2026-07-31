using UnityEngine;

public class WindChargeDirection : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    private Vector2 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        direction = player.position - transform.position;
        transform.Translate(direction*speed * Time.deltaTime);
    }
}
