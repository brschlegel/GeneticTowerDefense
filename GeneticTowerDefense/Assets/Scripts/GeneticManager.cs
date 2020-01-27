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
    public float mutationChance;
    public float mutationBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetFitness();
        fittest = new Chromosome(new List<float>() { 0, 0 });
        secondFittest = new Chromosome(new List<float>() { 0, 0 });
        mutationBounds = .3f;
        mutationChance = .2f;
     
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
       
        for (int i = 0; i < sample.Data.Count; i++)
         {
            target.Data[i] = sample.Data[i];
         }
    }

    public Chromosome CreateChromosome()
    {
        List<float> data = Mutate(seed);
       

        return new Chromosome(data);
    }

    public void CreateSeed()
    {
        List<float> data = new List<float>();
       
        if (fittest.DistTraveled != 0)
        {
            List<float>[] fittestData = fittest.Split(0);
            List<float>[] secFittestData = secondFittest.Split(0);
            data = Splice(fittestData[0], secFittestData[1]);
        }
        else
        {
            data.Add(.1f);
            data.Add(.1f);
        }
        Normalize(data);
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
            sum += f*f;
        }

       for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i] *list[i] / sum;
        }

        
    }

    public List<float> Mutate(List<float> data)
    {
        List<float> mutData = new List<float>();
       
        for(int i = 0; i < data.Count; i++)
        {
           
            if(Random.value <= mutationChance )
            {
                
                mutData.Add(Random.Range(-mutationBounds, mutationBounds) + data[i]);
            }
            else 
            {
                mutData.Add(data[i]);
            }
        }
        return mutData;
    }

    public void ResetFitness()
    {
        fittest = new Chromosome(new List<float>() { 0, 0 });
        secondFittest = new Chromosome(new List<float>() { 0, 0 });
    }
    
}
