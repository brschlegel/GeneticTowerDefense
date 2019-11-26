using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //handles building
    private Vector3 buildPosition;
    public BuildingLogic bl;
    public bool builtOn;
    public Transform towerToBuild;

   
    

    //handles color change
    public Material hoverMat;
    public Material normalMat;
    private bool hover;
    MeshRenderer render;
    

    void Start()
    {
        render = gameObject.GetComponent<MeshRenderer>();
        buildPosition = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
        bl = GameObject.FindGameObjectWithTag("GameController").GetComponent<BuildingLogic>();
        builtOn = false;
    }


    void OnMouseOver()
    {
        if (builtOn == false)
        {
            render.material = hoverMat;
            hover = true;
        }
        
    }

    void OnMouseExit()
    {
        if (builtOn == false)
        {
            render.material = normalMat;
            hover = false;
        }
    }




    void Update()
    {
        BuildTower(bl.TowerBought);
        
    }

    public void BuildTower(Transform towerPrefab)
    {
        if (Input.GetMouseButtonDown(0) && hover && bl.Bought && builtOn == false )
        {
            Instantiate(towerPrefab, buildPosition, transform.rotation);
            bl.Bought = false;
            builtOn = true;
        }
    }

    //Properties

    public Transform TowerToBuild
    {
        get { return towerToBuild; }
        set { towerToBuild = value; }
    }
}
