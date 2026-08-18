using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    //private
    //public

    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

    }

}
