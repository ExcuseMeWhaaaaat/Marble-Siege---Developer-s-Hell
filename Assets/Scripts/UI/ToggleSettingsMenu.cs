using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class ToggleSettingsMenu : MonoBehaviour
{
    [SerializeField] private Canvas settingsCanvas;
    public bool isVisible;
    

    

    public void TurnOn()
    {
        settingsCanvas.gameObject.SetActive(true);
    }
    public void TurnOff()
    {
        settingsCanvas.gameObject.SetActive(false);
    }

}
