using UnityEngine;

public class RainAttackMove : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float speed;
    public void MoveProjectile()
    {
        transform.Translate(speed * Time.deltaTime * direction.normalized);
        
    }

    public void Update()
    {
        MoveProjectile();
    }
}
