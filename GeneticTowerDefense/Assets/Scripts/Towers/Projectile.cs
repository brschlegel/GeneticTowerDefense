using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject target;
    protected EnemyMovement enemy;

    public float damage;
    public float speed = 30;
    public GameObject impactEffect;

    public Vector3 dir;
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
    public virtual void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


         dir = target.transform.position - transform.position;

        float dist = speed * Time.deltaTime;

        if (dir.magnitude <= dist)
        {
            //HitTarget();
            return;
        }

        transform.Translate(dir.normalized * dist, Space.World);
    }

    public abstract void HitTarget(EnemyMovement enemy);

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.gameObject.GetComponent<EnemyMovement>();
        Debug.Log(other);
        if (enemy != null)
        {
            HitTarget(other.gameObject.GetComponent<EnemyMovement>());

        }

    }


}
