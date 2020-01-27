using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;


    
    private int waveNum = 1;
    public int numDestroyed;
    private int numEnemies;
    public GeneticManager geneManager;
    public NextWave nextWave;
    public Transform spawnPoint;

    void Start()
    {
        geneManager = GetComponent<GeneticManager>();
    }

    void Update()
    {
        if (numDestroyed == numEnemies)
        {
            nextWave.SetEnabled(true);
        }


    }
    public void StartWave()
    {
        numDestroyed = 0;
        nextWave.SetEnabled(false);
        geneManager.CreateSeed();
        geneManager.ResetFitness();
        StartCoroutine(SpawnWave());

    }

    public int NumDestroyed
    {
        get { return numDestroyed; }
        set { numDestroyed = value; }

    }
    
    


    IEnumerator SpawnWave()
    {
        numEnemies = (int)(waveNum * Mathf.Sqrt(waveNum) + 3);

        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNum++;
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
