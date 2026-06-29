using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    public int experiencePoints;
    
    [SerializeField] private GameObject marbleSpawner;
    [SerializeField] float delay;
    [SerializeField] float repeatRate;
    [SerializeField] TextMeshProUGUI experienceInd;
    [SerializeField] Slider expBar;
    [SerializeField] int maxXP;
    [SerializeField] Button continueButton;
    
    void Start()
    {
        
        
        expBar.maxValue = maxXP;
        expBar.value = experiencePoints;
        experienceInd.text = "Experience Points: " + experiencePoints.ToString();
    }

    


    public void AddTotalExperience(int addAmount)
    {
        experiencePoints += addAmount;
        
        experiencePoints = Mathf.Clamp(experiencePoints, 0, maxXP);
        expBar.value = experiencePoints;
        experienceInd.text = "Experience Points: " + experiencePoints.ToString();
        if(maxXP > 100)
        {
            continueButton.enabled = true;
        }
    }

    
}
