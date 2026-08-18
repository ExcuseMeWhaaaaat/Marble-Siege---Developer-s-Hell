using UnityEngine;

public class StartInactive : MonoBehaviour
{
    [SerializeField] float delay;
    

    private void Start()
    {
        gameObject.SetActive(false);
        Invoke(nameof(SetToActive), delay);
    }

    public void SetToActive()
    {
        gameObject.SetActive(true);
    }
}
