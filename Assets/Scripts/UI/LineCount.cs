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
    [SerializeField] GameObject starterCircle;
    [SerializeField] private EnemySpawnController enemySpawnController;
    [SerializeField] private BossController bossController;
    

    private void Start()
    {
        StartPlay();

        EnableBossScript();
        EnableSpawnerScript();
        
    }
    private IEnumerator SiegeCountdown()
    {
        int colorIndex = 0;
        
        while (countdown > 0)
        {
            yield return new WaitWhile(() => GameManagement.instance.currentState == GameManagement.GameStates.Paused);
            yield return new WaitForSeconds(1f);
            countdown--;
            colorIndex++;
            countdownText.color = colorList[colorIndex];
            countdownText.text = countdown.ToString();
        }
        countdownText.text = "BEGIN THE SIEGE";
        countdownText.color = colorList[3];
        EnableBossScript();
        EnableSpawnerScript();
        StartCoroutine(FadeCoroutine(1));
        Destroy(starterCircle);
        
        
        
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

    public void EnableSpawnerScript()
    {
        if (enemySpawnController == null) return;
        if (enemySpawnController.enabled) return;
        
        enemySpawnController.enabled = true;
    }


    public void EnableBossScript()
    {
        if(bossController == null) return;
        if(bossController.enabled) return;
        
        bossController.enabled = true;
    }
}
