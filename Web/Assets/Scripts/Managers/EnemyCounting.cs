using TMPro;
using UnityEngine;

public class EnemyCounting : MonoBehaviour
{
    

    public int enemyCount;
    public static EnemyCounting instance;

    

    private void Awake()
    {
       
        instance = this;
    }
}
