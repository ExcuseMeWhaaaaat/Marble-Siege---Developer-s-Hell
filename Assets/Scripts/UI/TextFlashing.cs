using TMPro;
using UnityEngine;

public class TextFlashing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI warnText;
    [SerializeField] bool isRed;
   

    private void Start()
    {
        warnText.gameObject.SetActive(false);
        InvokeRepeating(nameof(AltColor), 1f,1f);
    }
    public void AltColor()
    {
        isRed = !isRed;
        SetTextColor();
    }

    public void SetTextColor()
    {
        if (isRed)
        {
            warnText.color = Color.red;
        }
        else
        {
            warnText.color = Color.white;
        }
    }
}
