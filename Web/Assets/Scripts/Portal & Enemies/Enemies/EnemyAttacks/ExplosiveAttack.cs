using UnityEngine;

public class ExplosiveAttack : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    
    public void Explode()
    {
        Instantiate(explosion,transform.position,transform.rotation);
    }

    private void OnDestroy()
    {
        Explode();
    }

    
}
