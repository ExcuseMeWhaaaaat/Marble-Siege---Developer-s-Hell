using UnityEngine;
using UnityEngine.Rendering;

public class EnemyTrack : MonoBehaviour
{
    [SerializeField] float speed;
    private GameObject player;
    private Vector2 direction;
    [SerializeField] float detectRange;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
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
