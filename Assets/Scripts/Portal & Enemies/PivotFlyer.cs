using UnityEngine;

public class PivotFlyer : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] string stateName;
    public void ScriptedLeave()
    {
        if (ScriptedTutorial.instance == null) return;
        if (ScriptedTutorial.instance.isGone)
        {
            FlyOut();
        }

    }

    public void FlyOut()
    {
        animator.Play(stateName);
    }
}
