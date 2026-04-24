using System.Collections;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class SkillPoints : MonoBehaviour
{
    public int skillPoints;
    public TextMeshProUGUI skillPointInd;
    [SerializeField] GameObject specialObject;
    [SerializeField] float abilityTime;
    [SerializeField] float fillInterval;
    [SerializeField] float abilityCooldown;
    public float meterAmount;
    public float maxMeterAmount;
    [SerializeField] TextMeshProUGUI meterInd;
    [SerializeField] Image fillImage;
    [SerializeField] float maxVal;
    [SerializeField] Slider meterSlider;
    [SerializeField] Color minColor;
    [SerializeField] Color maxColor;
    [SerializeField] float saturation;
    [SerializeField] float value;

    void Start()
    {
        InvokeRepeating(nameof(AutoFill), fillInterval, fillInterval);
        meterSlider.maxValue = maxVal;
        meterSlider.value = maxVal;
        skillPointInd.text = skillPoints.ToString();
        fillImage.color = minColor;
    }

    // Update is called once per frame
    void Update()
    {
        meterAmount = Mathf.Max(0f,meterAmount);
        meterSlider.value = meterAmount;
        float hue = Mathf.Lerp(0, 0.33f, meterSlider.normalizedValue);
        fillImage.color = Color.HSVToRGB(hue,1,1);
        

    }

    public void addSkillPoints(int pointsToAdd)
    {
        skillPoints += pointsToAdd;
        
        skillPointInd.text = skillPoints.ToString();
    }

    public void FillMeter(int fillAmount)
    {
        meterAmount += fillAmount;
        meterInd.text = "Meter Fill: " + meterAmount.ToString() + "/" + maxMeterAmount;
    }

    public void AutoFill()
    {
        meterAmount++;
        meterInd.text = "Meter Fill: " + meterAmount.ToString() + "/" + maxMeterAmount;
    }

    //public void SpecialAbility(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
        //{
            //SpawnChair();
            
        //}
        
    //}
    
    
   
    public void SpawnChair()
    {
        
        Instantiate(specialObject,transform.position,transform.rotation);
    }

    
}
