using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarbleBehavior : MonoBehaviour
{
    public Color goodColor;
    public Color badColor;
    public bool isBad = false;
    [SerializeField] SpriteRenderer colorRender;
    [SerializeField] float badChance;
    
    [SerializeField] private GameObject player;
    [SerializeField] float delay;
    [SerializeField] float repeatRate;
    [SerializeField] private GameObject marbleSpawner;
    [SerializeField] private MarbleSpawning marbleSpawning;
    [SerializeField] private EXP expScript;
    [SerializeField] float destroyChance;
    [SerializeField] float deleteRange;
    
    
    
    void Start()
    {
        InvokeRepeating(nameof(ChangeColor), delay,repeatRate);
        player = GameObject.FindGameObjectWithTag("Player");
        marbleSpawner = GameObject.FindGameObjectWithTag("Spawner");
        marbleSpawning = marbleSpawner.GetComponent<MarbleSpawning>();
        expScript = player.GetComponent<EXP>();
        
        
    }

    

    public void ChangeColor()
    {
        badChance = Random.Range(0, 100);
        if (badChance < 15)
        {
            colorRender.color = badColor;
            isBad = true;
            tag = "BadMarble";
            marbleSpawning.marbles--;
        }
        
    }

    

    
    

    

   

    

    public void CheckForBad()
    {
        int destroyNum = Random.Range(0, 100);
        if(destroyNum < destroyChance)
        {
            Destroy(gameObject);
            marbleSpawning.marbles--;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isBad && collision.gameObject.CompareTag("BadMarble"))
        {
            CheckForBad();
        }
    }
}
