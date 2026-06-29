using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesToSpawn", menuName = "Scriptable Objects/EnemiesToSpawn")]
public class EnemiesToSpawn : ScriptableObject
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<int> spawnChances = new List<int>();
    public List<int> enemyIDs = new List<int>();
}
