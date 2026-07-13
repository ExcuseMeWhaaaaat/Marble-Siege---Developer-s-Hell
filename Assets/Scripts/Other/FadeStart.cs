using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeStart : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    

    

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

    public void DeleteButton()
    {
        this.gameObject.SetActive(false);
    }

    
}
