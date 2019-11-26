using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTower : ParentTurret
{
    
    public GameObject target;

    

    [Header("Attributes")]
    
    public float fireRate = 2;
    private float fireCountdown = 0f;
    public float damage;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        damage = 10;
        range = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        //counts down the timer between firing
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.Initialize(damage);

        //Not sure why I have to do this but it works
        
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

   

    void UpdateTarget()
    {
        nearestEnemy = NearestEnemy(transform.position, range, GetEnemiesInRangeGO(transform.position, range));
        if (nearestEnemy != null)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }
}
