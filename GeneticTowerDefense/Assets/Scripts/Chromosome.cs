using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome
{
    public float distTraveled;

    //health, speed
    List<float> data;
    public float DistTraveled
    {
        get { return distTraveled; }
        set { distTraveled = value; }
    }

    public Chromosome(List<float> data)
    {
        this.data = data;
    }

    public List<float> Data 
    {
        get { return data; }
    }
    public float Health
    {
        get { return data[0]; }
    }

    public float Speed
    {
        get { return data[1]; }
    }
    
}
