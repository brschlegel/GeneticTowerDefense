using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLogic : MonoBehaviour
{
    private bool bought;
    public Transform towerBought;

    [Header("Tower Prefabs")]
    public Transform cubeTower;
    public Transform hourglass;
    public Transform slam;
 


    //properties
    public bool Bought
    {
        get { return bought; }
        set { bought = value; }
    }

    public Transform TowerBought
    {
        get { return towerBought; }
        set { towerBought = value; }
    }

    //Methods

    public void OnCubeTowerClick()
    {
        bought = true;
        towerBought = cubeTower;
    }

    public void OnHourglassClick()
    {
        bought = true;
        towerBought = hourglass;
    }

    public void OnSlamClick()
    {
        bought = true;
        towerBought = slam;
    }

    

    public void Start()
    {
        towerBought = null;
        bought = false;
    }
}
