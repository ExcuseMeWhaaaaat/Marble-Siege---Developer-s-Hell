using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] int enemiesPerWave;
    [SerializeField] float delay;
    [SerializeField] float repeatRate;
    [SerializeField] Vector2 bottomRight;
    [SerializeField] Vector2 topLeft;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject heavyEnemy;
    
    
    private int seconds;
    [SerializeField] Color warnColor;
    [SerializeField] Color defaultColor;
    [SerializeField] float warnTime;
    private SpriteRenderer spriteRenderer;
    public static EnemySpawner instance;



    //private void Awake()
    //{
    //if(instance != null && instance != this)
    //{
    //Destroy(gameObject);
    //else
    //instance = this;
    //}


    //}
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
        InvokeRepeating(nameof(SpawnEnemy), delay,repeatRate);
        InvokeRepeating(nameof(ChangeColor),delay-warnTime,repeatRate);
        
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
        SoundManagement.PlaySound(SoundType.Warn, 0.75f);
    }


    public Vector2 GenerateSpawnPos()
    {
        float xPos = Random.Range(bottomRight.x, topLeft.x);
        float yPos = Random.Range(bottomRight.y, topLeft.y);
        Vector2 spawnPos = new Vector2(xPos, yPos);
        return spawnPos;
    }
    public void SpawnEnemyType()
    {
        string enemySpawned = "";
        int spawnChance = Random.Range(0, 100);
        if(spawnChance < 11)
        {
            enemySpawned = "Heavy";
        }
        else
        {
            enemySpawned = "Normal";
        }
            switch (enemySpawned)
            {
                case "Normal":
                    ChooseToSpawn(enemy);
                    break;
                case "Heavy":
                    ChooseToSpawn(heavyEnemy);
                    break;
            }
    }

    public void ChooseToSpawn(GameObject enemy)
    {
        Instantiate(enemy,GenerateSpawnPos(),transform.rotation);
    }

    

    
}
