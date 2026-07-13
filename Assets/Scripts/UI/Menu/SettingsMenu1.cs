using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu1 : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;


    

    public void IsFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void SetVolume(float volume)
    {
        
        audioMixer.SetFloat("Volume", volume);
        SoundManagement.instance.masterVol = volume;
        
        
    }

    

    public void AutoDialogue(bool auto)
    {
        if(DialogueManager.Instance == null) return;
        DialogueManager.Instance.autoAdvance = auto;
        
        
        
    }
}
