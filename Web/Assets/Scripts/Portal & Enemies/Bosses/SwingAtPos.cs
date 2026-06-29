using System.Collections;
using UnityEngine;

public class SwingAtPos : MonoBehaviour
{
    public Transform playerPos;
    public Vector2 direction;
    public Vector2 otherDirection;
    public Transform thisPos;
    [SerializeField] float speed;
    [SerializeField] MeleeAttack meleeAttack;
    

    
    

    

    private void Update()
    {
        
        
        if (meleeAttack.meleeWeapon.activeSelf)
        {
            direction = (playerPos.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
            
        }
        else
        {
            transform.position = thisPos.position;
        }
        
        if(!meleeAttack.meleeWeapon.activeSelf)
        {
            GoBack();
        }
        
    }

    IEnumerator GoBack()
    {
        while(transform.position != thisPos.position)
        {
            otherDirection = (thisPos.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * otherDirection);
            yield return null;
        }
    }
}
