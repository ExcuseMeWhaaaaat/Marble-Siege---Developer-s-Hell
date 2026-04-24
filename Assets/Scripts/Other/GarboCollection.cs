using UnityEngine;

public class GarboCollection : MonoBehaviour
{
    [SerializeField] float timeToLive;
    void Start()
    {
        Invoke(nameof(Dissapear), timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Dissapear()
    {
        Destroy(gameObject);
    }
}
