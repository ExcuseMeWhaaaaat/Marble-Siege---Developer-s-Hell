using System.Collections;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField] float cooldown;
    [SerializeField] float activeTime;
    
    [SerializeField] float delay;
    [SerializeField] Animator animator;
    [SerializeField] string attackState;
    [SerializeField] string idleState;
    
    void Start()
    {
        gameObject.SetActive(false);
        InvokeRepeating(nameof(PlayAnim),delay,cooldown);
    }

    


    private void ActivateAttack()
    {
        
        gameObject.SetActive(true);
        StartCoroutine(UseBat());
    }

    IEnumerator UseBat()
    {
        yield return new WaitForSeconds(activeTime);
        ReturnToIdle();
        gameObject.SetActive(false);
    }

    public void PlayAnim()
    {
        if (animator == null) return;
        if (string.IsNullOrEmpty(attackState)) return;
        animator.Play(attackState);
        Invoke(nameof(ActivateAttack),1f);
        
    }
    
    public void ReturnToIdle()
    {
        if (animator == null) return;
        if (string.IsNullOrEmpty(idleState)) return;
        animator.CrossFade(idleState, 0.5f);
    }
}
