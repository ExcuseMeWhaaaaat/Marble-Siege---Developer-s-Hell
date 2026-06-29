using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField] float gracePeriod;
    private bool canHarm = false;
    private PlayerHeallth playerHeallth;
    private SkillPoints meterPoints;
    private GameObject player;
    
    void Start()
    {
        Invoke(nameof(EndPeriod), gracePeriod);
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if(!player)
            {
                enabled = false;
                return; 
            }
        }
        
        if(!meterPoints || !playerHeallth)
        {
            meterPoints = player.GetComponent<SkillPoints>();
            playerHeallth = player.GetComponent<PlayerHeallth>();
        }
        
    }

    

    public void EndPeriod()
    {
        canHarm = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canHarm && meterPoints.meterAmount < meterPoints.maxMeterAmount)
        {
            playerHeallth.CheckForHealth(1);
        }
        else
        {
            meterPoints.meterAmount -= 5;
        }
    }
}
