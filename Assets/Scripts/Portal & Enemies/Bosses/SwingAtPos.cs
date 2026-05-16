using System.Collections;
using UnityEngine;

public class SwingAtPos : MonoBehaviour
{
    public Transform playerPos;
    public Vector2 direction;
    public Transform thisPos;
    [SerializeField] float speed;
    

    private void Update()
    {
        float thisYPos = thisPos.position.y;
        thisYPos = playerPos.position.y;
    }


}
