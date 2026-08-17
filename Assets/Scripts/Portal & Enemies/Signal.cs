using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class BossHover : MonoBehaviour
{
    
    [SerializeField] bool goUp;
    
    [SerializeField] float hoverSpeed;

    private void Start()
    {
        goUp= true;
        InvokeRepeating(nameof(Hover), 1, 1);
    }
    public void Hover()
    {
        goUp = !goUp;
        
        
    }

    private void Update()
    {
        if (goUp)
        {
            transform.Translate(hoverSpeed * Time.deltaTime * Vector2.up);

        }

        if (!goUp)
        {
            transform.Translate(hoverSpeed * Time.deltaTime * Vector2.down);
        }
    }



}
