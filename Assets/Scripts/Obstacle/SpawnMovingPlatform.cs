using UnityEngine;

public class SpawnMovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject movingPlatform;
    
    [SerializeField] Transform spawnPos;
    [SerializeField] float interval;
    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnPlatform), interval, interval);
    }
    public void SpawnPlatform()
    {
        Instantiate(movingPlatform,spawnPos.position,transform.rotation);
    }
}
