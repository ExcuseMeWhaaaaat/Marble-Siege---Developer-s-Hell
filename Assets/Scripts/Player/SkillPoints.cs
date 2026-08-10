using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class SkillPoints : MonoBehaviour
{
    public int skillPoints;
    public TextMeshProUGUI skillPointInd;
    
    
    

    void Start()
    {
        
        
        skillPointInd.text = skillPoints.ToString();
        
    }

    
   

    public void addSkillPoints(int pointsToAdd)
    {
        skillPoints += pointsToAdd;
        
        skillPointInd.text = skillPoints.ToString();
    }

    public void AutoAddSkillPoints()
    {
        skillPoints++;
    }

    

    

    
}
