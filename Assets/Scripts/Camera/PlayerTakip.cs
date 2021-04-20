using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakip : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    Vector3 vector3;
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, player.transform.position.y+vector3.y, player.transform.position.z+vector3.z);
    }
}
