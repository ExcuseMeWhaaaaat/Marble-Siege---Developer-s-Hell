using UnityEngine;

public class TPBack : MonoBehaviour
{
    [SerializeField] float xBounds;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    [SerializeField] Vector2 direction;
    [SerializeField] float directionRange;

    private void Update()
    {
        transform.Translate(speed *Time.deltaTime*direction);
        if (transform.position.x > xBounds)
        {
            Teleport();
        } 
    }

    public void Teleport()
    {
        transform.position = startPos.position;
        direction = new Vector2(Random.Range(1,directionRange),0);
    }
}
