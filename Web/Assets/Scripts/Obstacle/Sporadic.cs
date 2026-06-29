using UnityEngine;

public class Sporadic : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float xDirectionRange;
    [SerializeField] float yDirectionRange;
    [SerializeField] float interval;
    [SerializeField] float rotSpeed;
    

    

    public Vector2 SetDirection()
    {
        float xDirection = Random.Range(-xDirectionRange,xDirectionRange);
        float yDirection = Random.Range(-yDirectionRange,yDirectionRange);
        Vector2 direction = new Vector2(xDirection, yDirection);
        Debug.Log(direction);
        return direction;
        
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * SetDirection());
        transform.Rotate(new Vector3(0,0,rotSpeed*Time.deltaTime));
    }
}
