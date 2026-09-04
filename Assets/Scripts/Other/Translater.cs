using UnityEngine;

public class Translater : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angle;
    void Start()
    {
        transform.Rotate(0,0,angle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }
}
