using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticManager : MonoBehaviour
{

    public Chromosome fittest;
    public Chromosome secondFittest;
    public float fitDist;
    public float secFitDist;
    public List<float> seed;
    
    // Start is called before the first frame update
    void Start()
    {
        fittest = new Chromosome(new List<float>() { 0, 0 });
        secondFittest = new Chromosome(new List<float>() { 0, 0 });
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecordFitness(Chromosome chromo)
    {
        if(fittest == null)
        {
            CopyChromosome(fittest, chromo);
            fitDist = fittest.DistTraveled;
        }
        else
        {
            if(chromo.DistTraveled > fittest.DistTraveled)
            {
                CopyChromosome(secondFittest, fittest);
                secFitDist = fitDist;
                CopyChromosome(fittest, chromo);
                fitDist = fittest.distTraveled;
            }
            else if(secondFittest ==null)
            {
                CopyChromosome(secondFittest, chromo);
                secFitDist = secondFittest.DistTraveled;
            }
        }
    }

    public void CopyChromosome(Chromosome target, Chromosome sample)
    {
        target.DistTraveled = sample.DistTraveled;
        target.Health = sample.Health;
        target.Speed = sample.Speed;
    }

    public Chromosome CreateChromosome()
    {
        return new Chromosome(seed);
    }

    public void CreateSeed()
    {
        List<float> data = new List<float>();
       
        if (fittest.DistTraveled != 0)
        {
            Debug.Log("bruh");
            List<float>[] fittestData = fittest.Split(1);
            List<float>[] secFittestData = secondFittest.Split(1);
            data = Splice(fittestData[0], secFittestData[1]);
           
        }
        else
        {
            data.Add(.3f);
            data.Add(.4f);
        }
        //Normalize(data);
        seed = data;
    }
    public List<float> Splice(List<float> front, List<float> back)
    {
        List<float> data = front;
        data.AddRange(back);
        return data;
    }

    public void Normalize(List<float> list)
    {
        float sum = 0;
        foreach (float f in list)
        {
            sum += f;
        }

       for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i] / sum;
        }

        
    }

    
}
