using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticManager : MonoBehaviour
{

    public Chromosome fittest;
    public Chromosome secondFittest;
    public float fitDist;
    public float secFitDist;
    
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
    }

    public Chromosome CreateChromosome()
    {
        List<float> data = new List<float>();
        data.Add(Random.value);
        data.Add(Random.value);
        Normalize(data);
        
        return new Chromosome(data);
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
