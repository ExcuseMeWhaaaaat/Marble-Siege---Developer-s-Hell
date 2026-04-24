using UnityEngine;
using UnityEngine.InputSystem;

public class DeletebyKey : MonoBehaviour
{
    public void DeleteObject(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        
            Destroy(this.gameObject);
        
    }
}
