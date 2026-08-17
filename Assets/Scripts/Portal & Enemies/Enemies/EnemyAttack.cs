using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float delay;
    [SerializeField] float cooldown;
    [SerializeField] Animator animator;
    [SerializeField] string attackState;
    [SerializeField] string idleState;
    void Start()
    {
        InvokeRepeating(nameof(PlayEnemyAttack), delay, cooldown);
        
        InvokeRepeating(nameof(RepeatCoroutine), delay, cooldown);
        
    }

    

    public void SpawnProjectile()
    {
        Instantiate(projectile,transform.position,transform.rotation);
    }

    public IEnumerator PlayEnemyAttack()
    {
        if (string.IsNullOrEmpty(attackState)) yield break;
        if (animator == null) yield break;
        animator.Play(attackState);
        yield return new WaitForSeconds(1f); 
        ReturnToIdle();
        SpawnProjectile();
    }

    public void ReturnToIdle()
    {
        if (string.IsNullOrEmpty(idleState)) return;
        if (animator == null) return;
        animator.CrossFade(idleState, 0.5f);
    }

    public void RepeatCoroutine()
    {
        StartCoroutine(PlayEnemyAttack());
    }
}
