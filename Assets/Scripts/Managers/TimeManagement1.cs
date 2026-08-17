using UnityEngine;

public class TimeManagement1 : MonoBehaviour
{
    public static TimeManagement1 instance;
    [SerializeField] float gameSpeed;
    [SerializeField] bool levelStarted;

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

    private void Start()
    {
        levelStarted = false;
    }

    
}
