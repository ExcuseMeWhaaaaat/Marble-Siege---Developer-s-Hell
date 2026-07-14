using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeStart : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    public bool confirmableBattle;
    [SerializeField] TextMeshProUGUI confirmText;

    

    public void StartFadeIn()
    {
        
        if (GameManagement.instance.currentState == GameManagement.GameStates.Paused) return;
        
            StartCoroutine(FadeCoroutine(0));
            DialogueManager.Instance.StopDialogue();
        
        
    }

    private IEnumerator FadeCoroutine(float startAlpha)
    {
        float finalColorAlpha = canvasGroup.alpha;
        float time = 0;
        while (finalColorAlpha < 1)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, time);
            Invoke(nameof(DeleteButton), 1f);
            yield return null;
            
        }
        


    }

    public void ConfirmSkipToBattle()
    {
        if (confirmableBattle)
        {
            StartFadeIn();
        }
        else
        {
            confirmText.text = "U sure?";
            confirmableBattle = true;
        }
    }

    public void DeleteButton()
    {
        this.gameObject.SetActive(false);
    }

    
}
