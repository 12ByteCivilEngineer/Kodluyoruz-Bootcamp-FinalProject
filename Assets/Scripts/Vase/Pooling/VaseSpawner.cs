using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSpawner : MonoBehaviour
{
    VasePooler vasePooler;
    GameObject player;

    float timer;
    public static bool isSpawned;
    bool isInside = false;

    private void Start()
    {
        vasePooler = VasePooler.Instance;
        player = GameObject.FindGameObjectWithTag("Root");      
    }
    private void Update()
    {
        if (Mathf.Abs(player.transform.position.y - transform.position.y) < 25f)
        {
            isInside = true;
        }
    }



    //private void FixedUpdate()
    //{
    //    if (Pavement.isGameStarted)
    //    {
    //        timer += Time.deltaTime;
    //        if (timer >= 5f)
    //        {

    //            Spawn();
    //            timer = 0f;
    //        }
    //        else
    //        {
    //            isSpawned = false;
    //        }
    //    }

    //}

    void Spawn()
    {
        isSpawned = true;
        GameObject go = vasePooler.SpawnFromPool("Vase", transform.position, Quaternion.identity) as GameObject;
        go.transform.parent = transform;


    }
    private void FixedUpdate()
    {
        if (Pavement.isGameStarted)
        {

            timer += Time.deltaTime;
            if (timer >= 5f && isInside)
            {
                Spawn();
                timer = 0f;
            }
        }

    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        isInside = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        isInside = false;
    //    }
    //}
}
