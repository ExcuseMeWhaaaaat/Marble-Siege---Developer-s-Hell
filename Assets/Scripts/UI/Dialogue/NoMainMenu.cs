using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NoMainMenu : MonoBehaviour
{
    public List<string> notHere;
    public void DeactivateOnMenu()
    {
        if(notHere.Contains(SceneManager.GetActiveScene().name))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DeactivateOnMenu();
    }

    private void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
