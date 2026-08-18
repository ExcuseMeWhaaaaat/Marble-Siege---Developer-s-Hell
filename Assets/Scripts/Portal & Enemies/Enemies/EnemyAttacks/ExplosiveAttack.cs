using UnityEngine;

public class ExplosiveAttack : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    
    public void Explode()
    {
        
        Instantiate(explosion,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (explosion == null) return;
        if (!Application.isPlaying) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }
}
