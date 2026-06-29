using UnityEngine;

public class Boom : MonoBehaviour
{
    
    [SerializeField] float fadeSpeed;
    [SerializeField] SpriteRenderer boomSprite;
    [SerializeField] float t = 0f;

    private void Update()
    {
        Color c = boomSprite.color;
        c.a -= fadeSpeed * Time.deltaTime;
        
        boomSprite.color = c;
        if (boomSprite.color.a < 0.01)
        {
            Destroy(gameObject);
        }
    }
}
