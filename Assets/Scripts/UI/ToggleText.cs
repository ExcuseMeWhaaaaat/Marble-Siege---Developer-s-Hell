using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{

    [SerializeField] Image titleImage;

    [SerializeField] float speed;
    
    [SerializeField] RectTransform finalRectPos;
    
    
    
    

    private void Start()
    {
        TranslateText();
    }
    
    
    public IEnumerator ChangePos()
    {
        yield return new WaitForSeconds(1f);
        
        while (Vector2.Distance(titleImage.rectTransform.anchoredPosition, finalRectPos.anchoredPosition) > 0)
        {
            
            Debug.Log("Do something!");
            titleImage.rectTransform.anchoredPosition = Vector2.MoveTowards(titleImage.rectTransform.anchoredPosition, finalRectPos.anchoredPosition, speed * Time.deltaTime);
            yield return null;
        }
        titleImage.rectTransform.anchoredPosition = finalRectPos.anchoredPosition;
    }
    
    public void TranslateText()
    {
        StartCoroutine(ChangePos());
    }


    
}
