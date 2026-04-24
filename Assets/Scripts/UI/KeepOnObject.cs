using TMPro;
using UnityEngine;

public class KeepOnObject : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textObject;
    
    

    private void Start()
    {
        textObject.text = "";
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        textObject.text = "Enter";
        
    }
}
