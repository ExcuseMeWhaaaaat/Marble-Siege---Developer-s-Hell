using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneFade : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    
    


    private void Start()
    {
        FadeFromBlack();
    }
    public IEnumerator FadeColor()
    {
        yield return new WaitForSeconds(1f);
        Color colorAlpha = fadeImage.color;
        while(colorAlpha.a != 0)
        {
            colorAlpha.a -= Time.deltaTime;
            fadeImage.color = colorAlpha;
            yield return null;
            
        }
        Destroy(fadeImage.gameObject);
    }

    public void FadeFromBlack()
    {
        StartCoroutine(FadeColor());
    }
}
