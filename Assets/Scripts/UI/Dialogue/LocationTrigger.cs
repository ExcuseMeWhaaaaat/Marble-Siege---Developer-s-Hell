using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LocationTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform triggerPos;
    [SerializeField] string targetCutscene;
    public bool canTrigger;
    [SerializeField] TextMeshProUGUI pressThisText;
    public string text;


    private void Start()
    {
        if(pressThisText == null)
        {
            Debug.Log("No Text");
            return;
        }
        pressThisText.text = "";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTrigger = true;
        pressThisText.text = text;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canTrigger = false;
        pressThisText.text = null;
    }

    public void CutsceneTrigger(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started) return;

        if (player == null || triggerPos == null)
        {
            Debug.Log("No Cutscene");
            return;
        }
        if (canTrigger)
        {
            SceneManager.LoadScene(targetCutscene);  
        }

    }
}
