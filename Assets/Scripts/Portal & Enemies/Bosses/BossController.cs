using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] float interval;
    [SerializeField] private BossAttackSelection bossAttackSelection;
    [SerializeField] private List<BossAttack> bossAttacks;
    [SerializeField] private CharacterAnimationController charAnim;
    public bool isAttacking;
    public bool usingPowerful;
    public List<GameObject> powerfulObjects;
    public List<int> hpThresholds;
    public List<int> hpWarnThresholds;
    public List<float> delays;
    
    [SerializeField] float speed;
    
    public int powerfulAttackIndex = 0;
    [SerializeField] List<Transform> transforms;
    [SerializeField] Transform target;
    [SerializeField] TextMeshProUGUI warnText;
    private void Start()
    {

        InvokeRepeating(nameof(UseIntervalAttack), interval, interval);

    }
    public void UseIntervalAttack()
    {
        if (ScriptedTutorial.instance != null)
        {
            if (ScriptedTutorial.instance.fightEnded) return;
        }
        
        ChooseAttack();
    }

    public void ChooseAttack()
    {
        if (bossAttackSelection == null) return;

        if (usingPowerful) return;
        if (isAttacking) return;



        isAttacking = true;
        //Randomly choose an attack to execute
        int attackIndex = Random.Range(0, bossAttacks.Count);
        
        BossAttack attack = bossAttacks[attackIndex];
        attack.Execute();
        if (charAnim != null)
        {
            charAnim.animator.CrossFade(attack.animClip.name, charAnim.translationDuration);
        }
        

    }

    public void ReturnToIdle()
    {
        isAttacking = false;
        charAnim.animator.CrossFade(bossAttackSelection.idleAnim.name, charAnim.translationDuration);
    }

    

    public void SummonPowerfulAttack()
    {
        warnText.gameObject.SetActive(false);
        Instantiate(powerfulObjects[powerfulAttackIndex], transforms[powerfulAttackIndex].position, transform.rotation);
        Invoke(nameof(Back), delays[powerfulAttackIndex]);
    }

    
    public void Back()
    {
        
        usingPowerful = false;
        
        
        if (powerfulAttackIndex >= 0 && powerfulAttackIndex < powerfulObjects.Count)
            powerfulObjects[powerfulAttackIndex] = null;
        powerfulAttackIndex++;
        
        
    }

    public void AttackWarning()
    {
        warnText.gameObject.SetActive(true);
    }
    

    
}
