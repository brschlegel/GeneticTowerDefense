﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{


    

    public override void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        enemy = target.GetComponent<EnemyMovement>();
        enemy.TakeDamage(damage);
        
        Destroy(effectIns,2f);


        Destroy(gameObject);

    }

}
