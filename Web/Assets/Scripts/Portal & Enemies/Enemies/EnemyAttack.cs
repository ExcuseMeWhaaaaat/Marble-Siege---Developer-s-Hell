using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float delay;
    [SerializeField] float cooldown;
    void Start()
    {
        InvokeRepeating(nameof(SpawnProjectile),delay,cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnProjectile()
    {
        Instantiate(projectile,transform.position,transform.rotation);
    }
}
