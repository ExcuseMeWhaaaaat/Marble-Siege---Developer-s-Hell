using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI credits;
    [SerializeField] Image creditImage;

    public void OnHover()
    {
        credits.gameObject.SetActive(true);
        creditImage.gameObject.SetActive(true);
    }

    public void OffHover()
    {
        credits.gameObject.SetActive(false);
        creditImage.gameObject.SetActive(false);
    }
}
