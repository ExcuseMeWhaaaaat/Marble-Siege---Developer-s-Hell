using UnityEngine;
using UnityEngine.UI;

public class OpenResetPanel : MonoBehaviour
{
    public Image confirmImage;
    public void OpenReseter()
    {
        confirmImage.gameObject.SetActive(true);
    }

    public void DontReset()
    {
        confirmImage.gameObject.SetActive(false);
    }
}
