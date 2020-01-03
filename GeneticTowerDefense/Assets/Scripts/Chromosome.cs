using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome 
{
    public float distTraveled;
    public float DistTraveled
    {
        get { return distTraveled; }
        set { distTraveled = value;  }
    }

    void Start()
    {
        distTraveled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
