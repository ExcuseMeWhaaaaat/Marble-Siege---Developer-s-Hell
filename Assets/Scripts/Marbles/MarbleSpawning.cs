using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarbleSpawning : MonoBehaviour
{
    [SerializeField] GameObject marble;
    [SerializeField] int marblesToSpawn;
    [SerializeField] Transform marbleSpawnPos;
    [SerializeField] TextMeshProUGUI marbleIndicator;
    [SerializeField] float interval;
    
    public int marbles;
    void Start()
    {
        marblesToSpawn = 10;
        SpawnMarbleAtStart();
        InvokeRepeating(nameof(SpawnMarbleAtInterval), interval, interval);    
           
    }

    // Update is called once per frame
    void Update()
    {
        marbles = Mathf.Max(0, marbles);
        
        marbleIndicator.text = "Marbles: " + marbles.ToString();
        

    }

    public void SpawnMarbleAtStart()
    {
        
        for(int i = 0; i < marblesToSpawn;i++)
        {
            Instantiate(marble,marbleSpawnPos.position, Quaternion.identity);
            marbles++;
            
        }
        
        
        
    }

    public void SpawnMarbleAtInterval()
    {
        if (marbles < 1)
        {
            return;
        }
        AddSpawnNum();
        SpawnMarbleAtStart();
    }


    public void AddSpawnNum()
    {
        marblesToSpawn += (int)Random.Range(1,marblesToSpawn*0.5f);
    }

    
}
