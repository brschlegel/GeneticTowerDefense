using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercerBullet : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    public override void HitTarget()
    {
        enemy = target.GetComponent<EnemyMovement>();
        enemy.TakeDamage(damage);
    }

}
