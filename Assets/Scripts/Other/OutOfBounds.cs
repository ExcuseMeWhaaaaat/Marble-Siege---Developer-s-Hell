using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] float yLevelThreshold;
    [SerializeField] GameObject enemySpawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yLevelThreshold)
        {
            transform.position = enemySpawnPoint.transform.position;
        }
    }
}
