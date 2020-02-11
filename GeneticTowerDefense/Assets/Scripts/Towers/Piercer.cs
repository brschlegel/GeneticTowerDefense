using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piercer : ParentTurret
{
    
    public float damage;
   
    public GameObject piercerBulletPrefab;
    public Transform firePoint;

    public float fireRate = 2;
    private float fireCountdown = 0f;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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
        GameObject bulletGO = (GameObject)Instantiate(piercerBulletPrefab, firePoint.position, firePoint.rotation);
        PiercerBullet bullet = bulletGO.GetComponent<PiercerBullet>();
        bullet.Initialize(damage);

        //Not sure why I have to do this but it works

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    
}
