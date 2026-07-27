using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            
        }
    }
}
