using System.Collections;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField] float cooldown;
    [SerializeField] float activeTime;
    
    [SerializeField] float delay;
    
    void Start()
    {
        InvokeRepeating(nameof(ActivateAttack),delay,cooldown);
    }

    


    private void ActivateAttack()
    {
        gameObject.SetActive(true);
        StartCoroutine(UseBat());
    }

    IEnumerator UseBat()
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }

    
}
