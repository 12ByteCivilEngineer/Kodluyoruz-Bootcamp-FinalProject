using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakip : MonoBehaviour
{
    public GameObject player;
    public float deneme;
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, player.transform.position.y+deneme, transform.position.z);
    }
}
