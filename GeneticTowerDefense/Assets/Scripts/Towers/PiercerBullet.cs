using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercerBullet : Projectile
{

    List<EnemyMovement> hasHit;
    void Start()
    {
        hasHit = new List<EnemyMovement>();
        speed = 50;
    }

    public override void Update()
    {
        //only adjusts direction of movement to guarentee one hit
        if (hasHit.Count == 0)
        {
            dir = target.transform.position - transform.position;
        }

        float dist = speed * Time.deltaTime;

        

        transform.Translate(dir.normalized * dist, Space.World);
    }

   
    public override void HitTarget(EnemyMovement enemy)
    {
       
        if (!hasHit.Contains(enemy))
        {
            enemy.TakeDamage(damage);
            hasHit.Add(enemy);
        }
        target = null;
        
      

    }

    

}
