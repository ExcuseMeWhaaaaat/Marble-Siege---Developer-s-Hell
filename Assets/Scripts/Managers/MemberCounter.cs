using TMPro;
using UnityEngine;

public class MemberCounter : MonoBehaviour
{
    [SerializeField] int memberCount;
    [SerializeField] TextMeshProUGUI memberText;

    void Start()
    {
        
    }

    
    void Update()
    {
        memberText.text = "Members: " + memberCount.ToString();
    }

    public void changeMemberCount(int memberNum)
    {

    }
}
