using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VelPad : MonoBehaviour
{
    public Transform teleportTarget;
    public HashSet<string> allowedColliders = new HashSet<string>() { "Player", "Marble", "BadMarble"};
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (allowedColliders.Contains(collision.gameObject.tag))
        {
            collision.transform.position = teleportTarget.position;
        }
    }


}
