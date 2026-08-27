using UnityEngine;

public class FlyOverTo : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;
    [SerializeField] Transform stop;

    private void Update()
    {
        float stopDist = Vector2.Distance(transform.position, stop.position);
        if(stopDist > 1f)
        {
            transform.Translate(speed * Time.deltaTime * direction);
        }
        else
        {
            transform.Translate(Vector2.zero);
        }
        
    }
}
