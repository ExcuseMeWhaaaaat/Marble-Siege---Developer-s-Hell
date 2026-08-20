using UnityEngine;

public class HealCollide : MonoBehaviour
{
    [SerializeField] PortalHealth portalHealth;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            

        }
    }
}
