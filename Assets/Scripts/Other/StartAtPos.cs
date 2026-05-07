using UnityEngine;

public class StartAtPos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }

    
}
