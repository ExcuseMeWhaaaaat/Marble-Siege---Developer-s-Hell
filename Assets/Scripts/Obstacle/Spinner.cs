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
        transform.Rotate(rotSpeed * Time.deltaTime, rotSpeed * Time.deltaTime, rotSpeed * Time.deltaTime);
    }
}
