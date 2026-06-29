using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] GameObject grassPf;
    [SerializeField] Transform bottomRight;
    [SerializeField] Transform topLeft;
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
        float xPos = Random.Range(bottomRight.position.x, topLeft.position.x);
        float yPos = Random.Range(bottomRight.position.y, topLeft.position.y);
        Vector2 spawnPos = new Vector2(xPos, yPos);
        return spawnPos;
    }
}
