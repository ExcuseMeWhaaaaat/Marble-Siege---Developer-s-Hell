using UnityEngine;

public class TimeManagement : MonoBehaviour
{
    public static TimeManagement instance;
    [SerializeField] float scale;
    public float timer;

    private void Update()
    {
        timer = Time.unscaledDeltaTime;
    }
}
