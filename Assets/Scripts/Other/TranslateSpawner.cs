using UnityEngine;

public class TranslateSpawner : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float interval;
    [SerializeField] GameObject spawn;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEffect), 0,interval);
    }

    public void SpawnEffect()
    {
        Instantiate(effect,spawn.transform.position,transform.rotation);
    }
}
