using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class EnemyTrack : MonoBehaviour
{
    [SerializeField] float speed;
    private GameObject player;
    
    [SerializeField] float detectRange;
    private SpriteRenderer sr;
    [SerializeField] float yAngle;
    [SerializeField] float flippedAngle;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(player.transform.position, transform.position);
        float xDirection = Mathf.Sign(player.transform.position.x - transform.position.x);

        // Face player
        

        if (distance > detectRange)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * xDirection, Space.World);
        }

        if(player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0,flippedAngle,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, yAngle, 0);
        }

    }

    
}
