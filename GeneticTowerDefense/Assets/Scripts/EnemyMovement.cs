
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float fixedSpeed;

    public GameObject gameManager;
    private WaveSpawner waveSpawner;
    private Transform target;
    private int waypointIndex = 0;
    public float health;
    public GeneticManager geneManager;
   
    public Chromosome chromo;

  
    public Chromosome Chromo
    {
        get { return chromo; }
        set { chromo = value; }
    }
    void Start()
    {
        target = Waypoints.points[0];
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        waveSpawner = gameManager.GetComponent<WaveSpawner>();
        geneManager = gameManager.GetComponent<GeneticManager>();
        chromo = geneManager.CreateChromosome();
        health = chromo.Health * 40 ;
        speed = chromo.Speed * 20;
        fixedSpeed = speed;
       
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        chromo.DistTraveled += (dir.normalized * speed * Time.deltaTime).magnitude;
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (health <= 0)
        {

            geneManager.RecordFitness(chromo);
            DestroyEnemy(gameObject);
            return;
        }
        
    }

    void GetNextWaypoint()
    {
        waypointIndex++;
        target = Waypoints.points[waypointIndex];

        //Destroys object if at end
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            DestroyEnemy(gameObject);
            return;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void DestroyEnemy(GameObject obj)
    {
        Destroy(obj);
        waveSpawner.NumDestroyed = waveSpawner.numDestroyed + 1;
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float FixedSpeed
    {
        get { return fixedSpeed; }
    }

}
