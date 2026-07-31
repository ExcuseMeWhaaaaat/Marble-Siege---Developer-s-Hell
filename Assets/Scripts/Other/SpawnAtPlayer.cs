using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject windCharge;
    [SerializeField] Transform thisTransform;

    private void Start()
    {
        SpawnWindCharge();
    }

    public void SpawnWindCharge()
    {
        Debug.Log("Spawned Wind Charge!");
        Instantiate(windCharge,thisTransform.position,thisTransform.rotation);
    }
    
    
}
