using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private CutsceneDirector cutsceneDirector;
    private void Start()
    {
        cutsceneDirector.Play();
    }
    


    
}
