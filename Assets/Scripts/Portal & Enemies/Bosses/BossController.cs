using NUnit.Framework;
using System.Collections.Generic;
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
    public List<float> delays;
    
    
    public int powerfulAttackIndex = 0;
    [SerializeField] List<Transform> transforms;

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
        Instantiate(powerfulObjects[powerfulAttackIndex], transforms[powerfulAttackIndex].position, transform.rotation);
        
        Invoke(nameof(Back), delays[powerfulAttackIndex]);
    }

    public void FlyOut()
    {

    }

    public void Back()
    {
        usingPowerful = false;
        powerfulObjects[powerfulAttackIndex] = null;
        if (powerfulAttackIndex >= 0 && powerfulAttackIndex < powerfulObjects.Count)
            powerfulAttackIndex++;
        
        
    }

    
    
}
