using System.Collections.Generic;
using UnityEngine;

public class WarningFlash : MonoBehaviour
{
    [SerializeField] bool isRed;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject cage;
    [SerializeField] Color flashColor;


    private void Start()
    {
        InvokeRepeating(nameof(FlashChange),0.25f,0.25f);
        Invoke(nameof(Activate), 1.5f);
    }

    public void FlashChange()
    {
        isRed = !isRed;
        if (isRed)
        {
            spriteRenderer.color = flashColor;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void Activate()
    {
        Instantiate(cage, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
}
