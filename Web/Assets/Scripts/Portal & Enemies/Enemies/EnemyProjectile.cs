using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private Vector2 direction;
    
    [SerializeField] float speed;
    
    //For later
    
    public string attackType;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        
        
        Invoke(nameof(SelfDelete), 5);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        
        transform.Translate(direction * speed * Time.deltaTime );
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            SelfDelete();
        }

    }

    private void SelfDelete()
    {
        Destroy(gameObject);
    }
}
