using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    
    [SerializeField] int enemiesPerWave;
    [SerializeField] float delay;
    [SerializeField] float repeatRate;
    [SerializeField] Transform bottomRight;
    [SerializeField] Transform topLeft;
    
    private int seconds;
    [SerializeField] Color warnColor;
    [SerializeField] Color defaultColor;
    [SerializeField] float warnTime;
    private SpriteRenderer spriteRenderer;
    public static EnemySpawnController instance;
    public List<GameObject> normalEnemies = new List<GameObject>();
    public List<GameObject> miscEnemies = new List<GameObject>();
    public GameObject heavyEnemy;
    public int heavySpawnChance;
    public int miscSpawnChance;
    

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }

    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), delay, repeatRate);
        InvokeRepeating(nameof(ChangeColor), delay - warnTime, repeatRate);

        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (!spriteRenderer)
            {
                enabled = false;
                return;
            }
        }

    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemyType();
            EnemyCounting.instance.enemyCount++;

        }
        spriteRenderer.color = defaultColor;
    }

    private void ChangeColor()
    {
        spriteRenderer.color = warnColor;
        if(SoundManagement.instance != null)
        {
            SoundManagement.PlaySound(SoundType.Warn, 0.75f);
        }
        
    }

    public Vector2 GenerateSpawnPos()
    {
        float xPos = Random.Range(topLeft.position.x, bottomRight.position.x);
        
        Vector2 spawnPos = new Vector2(xPos, 0);
        return spawnPos;
    }
    public void SpawnEnemyType()
    {
        int spawnChance = Random.Range(0, 100);
        
        if(spawnChance < heavySpawnChance)
        {
            ChooseToSpawn(heavyEnemy);
        }
        else if(spawnChance < miscSpawnChance)
        {
            ChooseToSpawn(miscEnemies[Random.Range(0,miscEnemies.Count)]);
        }
        else
        {
            ChooseToSpawn(normalEnemies[Random.Range(0, normalEnemies.Count)]);
        }
            
    }

    public void ChooseToSpawn(GameObject enemy)
    {
        Instantiate(enemy, GenerateSpawnPos(), transform.rotation);
    }
}
