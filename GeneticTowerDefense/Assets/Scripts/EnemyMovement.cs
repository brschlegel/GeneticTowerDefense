
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float fixedSpeed = 10f;

    public GameObject gameManager;
    private WaveSpawner waveSpawner;
    private Transform target;
    private int waypointIndex = 0;
    public float health;
    public float distTraveled;
    public Chromosome chromo;

    public float DistTraveled
    {
        get { return distTraveled; }
    }

    public Chromosome Chromo
    {
        get { return chromo; }
        set { chromo = value; }
    }
    void Start()
    {
        target = Waypoints.points[0];
        health = 30;
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        waveSpawner = gameManager.GetComponent<WaveSpawner>();
        distTraveled = 0;
        speed = fixedSpeed;
        chromo = GetComponent<Chromosome>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        distTraveled += (dir.normalized * speed * Time.deltaTime).magnitude;
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (health <= 0)
        {


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
