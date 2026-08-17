using UnityEngine;

public class AllyExecuteAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string animState;

    
    public void Awake()
    {

        animator.Play(animState);
        Debug.Log(animState);
        Debug.Log("Started");
    }
}
