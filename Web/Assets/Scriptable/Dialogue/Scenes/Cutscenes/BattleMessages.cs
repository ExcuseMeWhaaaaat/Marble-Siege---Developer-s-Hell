using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleMessages", menuName = "Scriptable Objects/BattleMessages")]
public class BattleMessages : ScriptableObject
{
    [TextArea] public List<string> messages;

    
}
