using TMPro;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public TextMeshProUGUI zoneClearedSign;
    private PortalHealth portalHP;
    
    public bool zoneComplete = false;
    private static SceneManagement instance;

    void Awake()
    {
        if (!EnemyCounting.instance)
        {
            enabled = false;
            return;
        }


        //portalHP = GameObject.Find("Portal").GetComponent<PortalHealth>();
        portalHP = GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalHealth>();
    }

    // Update is called once per frame
    void Check()
    {
        if (portalHP != null && EnemyCounting.instance)
        {
            if (EnemyCounting.instance.enemyCount < 1 && portalHP.portalHP < 1)
            {
                zoneClearedSign.text = "Area Complete!";
                zoneComplete = true;
            }
            else
            {
                zoneClearedSign.text = "";
            }
        }
        
    }
}
