using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WindCharging : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        float yDirection = player.position.y - transform.position.y;
        Vector2 direction = new Vector2(0, yDirection);
        transform.Translate(5* Time.deltaTime* direction);
    }

}
