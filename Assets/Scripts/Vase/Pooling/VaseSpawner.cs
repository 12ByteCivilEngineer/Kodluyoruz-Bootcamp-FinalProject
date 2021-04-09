using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSpawner : MonoBehaviour
{
    VasePooler vasePooler;
    float timer;

    private void Start()
    {
        vasePooler = VasePooler.Instance;
        
    }

    private void FixedUpdate()
    {
        if (Pavement.isGameStarted)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                Spawn();
                timer = 0f;
            }
        }
        
    }

    void Spawn()
    {
        GameObject go = vasePooler.SpawnFromPool("Vase", transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform;
        
    }
}
