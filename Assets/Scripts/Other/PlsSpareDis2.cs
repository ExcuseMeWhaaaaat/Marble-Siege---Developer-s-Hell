using UnityEngine;

public class PlsSpareDis2 : MonoBehaviour
{
    public static PlsSpareDis2 instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }
}
