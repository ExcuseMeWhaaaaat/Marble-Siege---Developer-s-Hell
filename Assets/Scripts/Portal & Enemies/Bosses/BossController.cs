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
    

    private void Start()
    {
        InvokeRepeating(nameof(UseIntervalAttack), interval, interval); 
    }
    public void UseIntervalAttack()
    {
        
        ChooseAttack();
    }

    public void ChooseAttack()
    {
        if (bossAttackSelection == null) return;

        //If the boss is using a powerful attack, don't execute
        if (isAttacking) return;

        
        
        isAttacking = true;
        //Randomly choose an attack to execute
        int attackIndex = Random.Range(0, bossAttacks.Count);
        
        BossAttack attack = bossAttacks[attackIndex];
        attack.Execute();
        if(charAnim != null)
        {
            charAnim.animator.CrossFade(attack.animClip.name, charAnim.translationDuration);
        }
        
       
    }

    public void ReturnToIdle()
    {
        isAttacking = false;
        charAnim.animator.CrossFade(bossAttackSelection.idleAnim.name, charAnim.translationDuration);
    }
    
}
