using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private GameObject target;
    private EnemyMovement enemy;

    public float damage;
    public float speed = 30;
    public GameObject impactEffect;
    public void Seek(GameObject _target)
    {
        target = _target;
    }

    //Basically a constructor
    public void Initialize(float _damage)
    {
        damage = _damage;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 dir = target.transform.position - transform.position;

        float dist = speed * Time.deltaTime;

        if (dir.magnitude <= dist)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * dist, Space.World);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        enemy = target.GetComponent<EnemyMovement>();
        enemy.TakeDamage(damage);
        
        Destroy(effectIns,2f);


        Destroy(gameObject);

    }

}
