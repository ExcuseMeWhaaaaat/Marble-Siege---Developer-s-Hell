using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotSpeed * Time.deltaTime);
    }
}
