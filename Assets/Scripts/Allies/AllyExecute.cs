using UnityEngine;

public class AllyExecuteAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip clip;
    

    private void Start()
    {
        animator.CrossFade(clip.name, 0.5f);
    }
}
