using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{


    

    public override void HitTarget(EnemyMovement enemy)
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        
        enemy.TakeDamage(damage);

        Destroy(effectIns, 2f);


        Destroy(gameObject);

    }
    
}
