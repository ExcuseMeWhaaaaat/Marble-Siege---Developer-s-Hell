using UnityEngine;

public class BattleSceneChange : MonoBehaviour
{
    public void ConfirmSkipToBattle()
    {
        if(TakeToScene.instance.confirmable)
        {
            
        }
        else
        {
            TakeToScene.instance.Ensure();
        }
    }

}
