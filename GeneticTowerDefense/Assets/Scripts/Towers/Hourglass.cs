using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : ParentTurret
{

    public List<EnemyMovement> enemiesAll;

   
    // Start is called before the first frame update
    void Start()
    {
        enemiesAll = new List<EnemyMovement>();
        inRange = new List<EnemyMovement>();
        range = 15f;

        InvokeRepeating("UpdateList", 0f, 0.5f);
    }

    void UpdateList()
    {
        enemiesAll = GetEnemyScript(GetEnemiesInRangeGO(transform.position, Mathf.Infinity));
        inRange = GetEnemyScript(GetEnemiesInRangeGO(transform.position, range));
    }

    private void Update()
    {
        foreach (EnemyMovement e in enemiesAll)
        {
            if (inRange.Contains(e))
            {
                e.Speed = e.fixedSpeed  / 1.5f;
            }
            else
            {
                e.Speed = e.FixedSpeed;
            }
        }


    }
}
