using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedTutorial : MonoBehaviour
{
    public enum TutorialEvents
    {
        Heal,
    }

    public Dictionary<TutorialEvents,bool> completeEv;
    public static ScriptedTutorial instance;
    private void Awake()
    {
        completeEv = new Dictionary<TutorialEvents, bool>();
        if(instance != null && instance != this )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        completeEv.Add(TutorialEvents.Heal, false);
    }

    public void CompleteEvent(TutorialEvents eventName)
    {
        if (!completeEv[eventName])
        {
            completeEv[eventName] = true;
        }
        Debug.Log(completeEv[eventName]);
    }

    
}
