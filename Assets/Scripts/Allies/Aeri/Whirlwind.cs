using UnityEngine;

public class Whirlwind : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyProjectile enemyProjectile = collision.gameObject.GetComponent<EnemyProjectile>();
        if (enemyProjectile != null)
        {
            Destroy(enemyProjectile.gameObject);
        }
    }
}
