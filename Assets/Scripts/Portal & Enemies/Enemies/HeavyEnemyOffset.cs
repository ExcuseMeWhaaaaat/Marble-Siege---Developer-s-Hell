using UnityEngine;

public class HeavyEnemyOffset : MonoBehaviour
{
    [SerializeField] float yPos;
    

    private void Start()
    {
        transform.position = new Vector2(0,yPos);
    }
}
