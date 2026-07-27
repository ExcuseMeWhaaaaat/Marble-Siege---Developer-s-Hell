using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] List<Color> colorList;
    [SerializeField] int countdown;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] List<AudioClip> audioClipList;
    

    private void Start()
    {
        Time.timeScale = 0;

        StartPlay();
        
    }
    private IEnumerator SiegeCountdown()
    {
        int colorIndex = 0;
        while (countdown > 0)
        {
            if(GameManagement.instance.currentState == GameManagement.GameStates.Playing)
            {
                yield return new WaitForSecondsRealtime(1f);
                countdown--;
                colorIndex++;
                countdownText.color = colorList[colorIndex];

                countdownText.text = countdown.ToString();
            }
            else
            {
                yield return new WaitUntil(() => GameManagement.instance.currentState == GameManagement.GameStates.Playing);
            }
            
        }
        countdownText.text = "BEGIN THE SIEGE";
        countdownText.color = colorList[3];
        StartCoroutine(FadeCoroutine(1));
        Time.timeScale = 1;
    }
    
   
    private IEnumerator FadeCoroutine(float startAlpha)
    {
        float finalColorAlpha = canvasGroup.alpha;
        float time = 0;
        while (finalColorAlpha > 0)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, time);
            
            yield return null;

        }



    }

    public void StartPlay()
    {
        GameManagement.instance.currentState = GameManagement.GameStates.Playing;
        StartCoroutine(SiegeCountdown());
    }
}
