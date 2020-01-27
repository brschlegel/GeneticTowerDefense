using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome
{
    public float distTraveled;

    //health, speed, evasionRate
    List<float> data;

    public List<float>[] Split(int index)
    {
        List<float> front = new List<float>();
        List<float> back = new List<float>();
        
        for(int i = 0; i <= index; i++)
        {
           
            front.Add(data[i]);
        }
        for (int i = data.Count-1; i > index; i--)
        {
            back.Add(data[i]);
        }
        
        return new List<float>[2] { front, back };
    }
    #region Properties
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
        set { data[0] = value; }
    }

    public float Speed
    {
        get { return data[1]; }
        set { data[1] = value; }
    }

    public float EvasionRate
    {
        get { return data[2]; }
        set { data[2] = value; }
    }
    #endregion
}
