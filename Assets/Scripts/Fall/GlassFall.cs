using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFall : MonoBehaviour
{
    FallControl fallControl;
    float fallDistance = 5f;
    [SerializeField] ParticleSystem particleFX;
    MeshRenderer meshrenderer;
    Rigidbody body;
    BoxCollider boxCollider;
    private void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        fallControl = FindObjectOfType<FallControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            meshrenderer.enabled = false;
            boxCollider.enabled = false;
            body.isKinematic = true;
            particleFX.Play();
            fallControl.Fall(fallDistance);
            Destroy(gameObject, 3f);
        }
    }
}
