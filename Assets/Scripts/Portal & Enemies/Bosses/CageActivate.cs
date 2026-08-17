using UnityEngine;

public class CageActivate : MonoBehaviour

{
    [SerializeField] GameObject spikes;
    [SerializeField] string animState;
    [SerializeField] Animator animator;

    private void Start()
    {
        spikes.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spikes == null) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            spikes.SetActive(true);
            animator.Play(animState);
        }
        
    }
}
