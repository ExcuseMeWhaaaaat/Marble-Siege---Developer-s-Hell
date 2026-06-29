using UnityEngine;


public enum SoundType
{
    Damage,
    Hurt,
    Warn,
    Success,
    Fail,
    Heal,
    Click,
    
    Whirlwind,
    WindCharge,
    HealPool,
    Splash,
    
    FallingStar,
    
}
public class SoundManagement : MonoBehaviour
{
    public static SoundManagement instance;
    public AudioSource audioSource;
    [SerializeField] AudioClip[] soundList;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    

    public static void PlaySound(SoundType soundType, float volume)
    {
        if ((int)soundType >= instance.soundList.Length) return;
        instance.audioSource.PlayOneShot(instance.soundList[(int)soundType],volume);
    }

    
}
