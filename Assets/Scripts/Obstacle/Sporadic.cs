using UnityEngine;

public class Travel : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }
}
