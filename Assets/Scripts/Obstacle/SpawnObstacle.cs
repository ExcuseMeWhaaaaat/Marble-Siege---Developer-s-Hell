using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] GameObject grassPf;
    [SerializeField] Vector2 bottomRight;
    [SerializeField] Vector2 topLeft;
    [SerializeField] float delay;
    [SerializeField] float interval;
    [SerializeField] int numtoSpawn;
    void Start()
    {
        InvokeRepeating(nameof(SpawnGrass), delay, interval);
    }

    // Update is called once per frame
    

    public void SpawnGrass()
    {
        for(int i = 0;i < numtoSpawn;i++)
        {
            Instantiate(grassPf, GenerateSpawnPos(), transform.rotation);
        }
        
    }

    public Vector2 GenerateSpawnPos()
    {
        float xPos = Random.Range(bottomRight.x, topLeft.x);
        float yPos = Random.Range(bottomRight.y, topLeft.y);
        Vector2 spawnPos = new Vector2(xPos, yPos);
        return spawnPos;
    }
}
