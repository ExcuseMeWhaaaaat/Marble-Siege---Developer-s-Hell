using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;



public class TutorialManagement : MonoBehaviour
{

    public string msg;
    public
    string[] msgList = new string[9];

    private int indexClamped;
    public int currentStringIndex = 0;
    
    [SerializeField] TextMeshProUGUI newText;
    [SerializeField] float tick;
    private Coroutine coroutineType;


    void Start()
    {
        msg = msgList[0];
        newText.text = msg;
        TypeMessage();
    }



    public void TypeMessage()
    {
        if (coroutineType != null && currentStringIndex < msgList.Length)
        {
            StopCoroutine(coroutineType);
            currentStringIndex++;
            ChangeMessage();

        }
        coroutineType = StartCoroutine(Ticking());


    }

    public void moveToNext(InputAction.CallbackContext context)
    {
        if (context.performed && currentStringIndex >= 0 && currentStringIndex < msg.Length && currentStringIndex < msgList.Length)
        {
            TypeMessage();
            
        }
    }

    IEnumerator Ticking()
    {
        newText.text = "";
        for (int i = 0; i < msg.Length; i++)
        {
            newText.text += msg[i];

            yield return new WaitForSeconds(tick);
        }
    }

    public void ChangeMessage()
    {


        if (currentStringIndex >= 0 && currentStringIndex < msg.Length && msgList[currentStringIndex] != null)
        {
            msg = msgList[currentStringIndex];
            
        }
        


    }

    

   

}
