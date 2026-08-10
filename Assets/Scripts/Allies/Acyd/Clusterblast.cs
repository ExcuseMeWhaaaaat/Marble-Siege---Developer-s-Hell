using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    [SerializeField] GameObject acidDrop;
    [SerializeField] float delay;
    [SerializeField] float spawnRange;
    [SerializeField] float rainTime;


    private void Start()
    {
        StartCoroutine(SummonRain());
        rainTime = 10;
    }

    IEnumerator SummonRain()
    {
        while(rainTime > 0)
        {
            yield return new WaitForSeconds(1f);
            rainTime--;
            SpawnDrop();
        }
        Destroy(gameObject);
    }

    public Vector2 SpawnAtPos()
    {
        float xPos = transform.position.x + Random.Range(-spawnRange,spawnRange);
        float yPos = transform.position.y - 4;
        Vector2 spawnPos = new Vector2(xPos, yPos);
        return spawnPos;
    }

    public void SpawnDrop()
    {
        if (acidDrop == null) return;
        Instantiate(acidDrop,SpawnAtPos(),transform.rotation);
    }

}
