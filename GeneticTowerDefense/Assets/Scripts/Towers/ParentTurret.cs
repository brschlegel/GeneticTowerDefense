using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTurret : MonoBehaviour
{
    private GameObject[] enemies;
    
    
    public GameObject nearestEnemy;
    private string EnemyTag = "Enemy";
    public List<EnemyMovement> inRange;

    [Header("Attributes")]
    public float range;

    private void Start()
    {
        


    }

    
    public List<GameObject> GetEnemiesInRangeGO(Vector3 currentPosition, float range)
    {
         List<GameObject> enemiesInRangeGO = new List<GameObject>();
        enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        foreach (GameObject e in enemies)
        {
            if (Vector3.Distance(e.transform.position, currentPosition) <= range)
            {
                enemiesInRangeGO.Add(e);
            }
        }
        return enemiesInRangeGO;
    }

    //returns a list of enemy scripts from list of gameobjects
    public List<EnemyMovement> GetEnemyScript(List<GameObject> enemies)
    {
        List<EnemyMovement> enemyScripts = new List<EnemyMovement>();
        foreach (GameObject e in enemies)
        {
            enemyScripts.Add(e.GetComponent<EnemyMovement>());

        }
        return enemyScripts;
    }

    public GameObject NearestEnemy(Vector3 currentPosition, float range, List<GameObject> enemiesInRangeGO)
    {
        

        float shortestDistance = Mathf.Infinity;
        foreach (GameObject e in enemiesInRangeGO)
        {
            float distanceToEnemy = Vector3.Distance(currentPosition, e.transform.position);
            
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = e;

            }
        }
        return nearestEnemy;



    }
    

    void OnDrawGizmosSelected()
    {
        //draws range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }






}
    
   
