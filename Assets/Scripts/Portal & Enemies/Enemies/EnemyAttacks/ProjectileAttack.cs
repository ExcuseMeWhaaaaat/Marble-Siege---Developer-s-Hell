using UnityEngine;

public class ProjectileAttack : AbstractAttack
{
    [SerializeField] GameObject bullet;
    private Vector2 direction;
    [SerializeField] float attackCooldown;
    public override void Attack()
    {
        SpawnProjectile();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Attack),attackCooldown,attackCooldown);
    }
    
    public void SpawnProjectile()
    {
        Instantiate(bullet,transform.position,Quaternion.identity);
    }
}
