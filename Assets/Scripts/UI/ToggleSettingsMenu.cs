using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleSettingsMenu : MonoBehaviour
{
    public Canvas settingsCanvas;
    public Button settingsButton;
    public bool isVisible;
    [SerializeField] Slider volumeSlider;


    private void Start()
    {
        
        volumeSlider.value = 0.5f;
    }

    public void TurnOn()
    {
        settingsButton.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
    }
    public void TurnOff()
    {
        settingsButton.gameObject.SetActive(true);
        settingsCanvas.gameObject.SetActive(false);
    }

}
