using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamTower : ParentTurret
{

    private Animator anim;
    
    [Header("Attributes")]

   
    public float damage;
    public GameObject slamEffect;
    public Vector3 effectPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        inRange = new List<EnemyMovement>();
        range = 20;
        InvokeRepeating("UpdateList", 0f, 0.5f);
        damage = 6;
    }
    // Update is called once per frame
    void Update()
    {
        
            if (inRange.Count > 0)
            {
                anim.SetBool("Attacking", true);
               
            }
            
    }

    void UpdateList()
    {
        inRange = GetEnemyScript(GetEnemiesInRangeGO(transform.position, range));
    }

    //damage * ln(-distance + range + 1)
    void Attack()
    {
        foreach (EnemyMovement e in inRange)
        {
            float damageToTake = damage * Mathf.Log(-Vector3.Distance(e.transform.position, transform.position) + range + 1);
            
            e.TakeDamage(damageToTake);
        }
        effectPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject effectIns = (GameObject)Instantiate(slamEffect, effectPos, transform.rotation);
        Destroy(effectIns, 2f);
    }

    void EndAnim()
    {
        anim.SetBool("Attacking", false);
       
    }
}
