using UnityEngine;

public class HealingAbility : BossAttack
{
    [SerializeField] GameObject healer;
    [SerializeField] Transform spawnTransform;

    public override void Execute()
    {

    }
    public void SpawnHealer()
    {
        Instantiate(healer,spawnTransform.position,transform.rotation);
    }

    

        

}
