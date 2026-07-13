using UnityEngine;
using UnityEngine.UI;

public class DelayActivity : MonoBehaviour
{
    [SerializeField] Button battleButton;
    private void Start()
    {
        battleButton.gameObject.SetActive(false);
        Invoke(nameof(DelayButton),3f);
    }

    public void DelayButton()
    {

        battleButton.gameObject.SetActive(true);
    }
}
