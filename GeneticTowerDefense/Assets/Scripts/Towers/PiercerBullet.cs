using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercerBullet : Projectile
{
    void Start()
    {
        
    }

    // Update is called once per frame


    public override void HitTarget()
    {
        enemy = target.GetComponent<EnemyMovement>();
        enemy.TakeDamage(damage);
        target = null;
    }

}
