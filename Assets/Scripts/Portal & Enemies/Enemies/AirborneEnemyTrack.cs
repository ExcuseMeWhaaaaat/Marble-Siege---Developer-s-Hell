using UnityEngine;

public class AirborneEnemyTrack : MonoBehaviour
{
    [SerializeField] float speed;
    private GameObject player;
    private Vector2 direction;
    [SerializeField] float detectRange;
    [SerializeField] float yLevel;
    [SerializeField] float yRange;
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float yPos = transform.position.y;
        yPos = yLevel + Random.Range(-yRange,yRange);
        transform.position = new Vector2(transform.position.x,yPos);
    }

    
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (player != null && distance > detectRange)
        {
            direction.x = player.transform.position.x - transform.position.x;
            transform.Translate(speed * Time.deltaTime * direction.normalized);
        }
    }
}
