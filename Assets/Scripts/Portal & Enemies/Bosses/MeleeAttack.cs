using System.Collections;
using UnityEngine;

public class MeleeAttack : BossAttack
{
    public GameObject meleeWeapon;
    
      
    

    
    public override void Execute()
    {
        
    }

    private void Start()
    {
        Deactivate();
    }

    public void Activate()
    {
        meleeWeapon.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        meleeWeapon.gameObject.SetActive(false);
    }
}
