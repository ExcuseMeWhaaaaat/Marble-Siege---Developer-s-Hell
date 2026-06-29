using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CentralPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform camPos;
    
    
    void Start()
    {
        if (!camPos) return;
            camPos.position = transform.position + offset;
        
        if (!player) return;
            transform.position = player.transform.position;
    }

    
    void Update()
    {
        camPos.position = transform.position + offset;
        if (!player) return;
        
            transform.position = player.transform.position;
        
    }

   
}
