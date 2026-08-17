using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
