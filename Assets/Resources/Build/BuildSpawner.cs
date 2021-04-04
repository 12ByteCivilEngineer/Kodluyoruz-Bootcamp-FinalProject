using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{
    Transform buildContainer;
    
    public static GameObject[] buildObjects;

    public static int numSpawned = 0;
    [SerializeField]
    int buildnumber;

    void Start()
    {
        buildObjects = Resources.LoadAll<GameObject>("Prefabs");
    }
    

    public BuildSpawner(Transform buildContainer)
    {
        this.buildContainer = buildContainer;
    }

    public void Spawn()
    {
        int whichItem = Random.Range (0, 4);
        
        GameObject build = Instantiate (buildObjects[whichItem]) as GameObject;

        
        if(numSpawned == 0)
        {
            build.transform.position = new Vector3(0f,0f,0f);

        }
        else
        {
            build.transform.position = new Vector3(0f,numSpawned * 5.40f,0f);
        }
        
        numSpawned++;
        
    }

    void Update()
    {
        if(buildnumber > numSpawned)
        {
            
            Spawn();
        }
    }
}
