using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] float interval;
    [SerializeField] bool isActive;
    [SerializeField] float minVal;
    [SerializeField] float maxVal;

    void Start()
    {
        InvokeRepeating(nameof(Switch), interval,interval);
    }

    
    public void Switch()
    {
        interval = Random.Range(minVal, maxVal);
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }
}
