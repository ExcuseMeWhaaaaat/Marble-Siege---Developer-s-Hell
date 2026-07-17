using UnityEngine;

public class PivotFlyer : MonoBehaviour
{

    [SerializeField] private CharacterAnimationController charAnim;
    [SerializeField] private PivotFly pivotFly;
    public void ScriptedLeave()
    {
        if (ScriptedTutorial.instance == null) return;
        if (ScriptedTutorial.instance.isGone)
        {
            FlyOut();
            Debug.Log("Left");
        }

    }

    public void FlyOut()
    {
        charAnim.animator.CrossFade(pivotFly.doneClip.name, charAnim.translationDuration);
    }
}
