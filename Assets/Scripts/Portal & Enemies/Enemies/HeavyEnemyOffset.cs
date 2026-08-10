using UnityEngine;

public class HeavyEnemyOffset : MonoBehaviour
{
    [SerializeField] float yPos;
    

    private void Start()
    {
        transform.position = new Vector2(transform.position.x,yPos);
    }
}
