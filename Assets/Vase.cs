using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem particleFX;
    MeshRenderer meshrenderer;
    Rigidbody body;
    BoxCollider boxCollider;
    GameObject attentionImage;

    void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        attentionImage = GameObject.FindGameObjectWithTag("Attention");
        //attentionImage.SetActive(false);
    }

    private void Update()
    {
        int layerMask = LayerMask.GetMask("Player");
        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out raycastHit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * raycastHit.distance, Color.red);
            Debug.Log("Raycast çalışıyor");
            attentionImage.SetActive(true);
        }

        else
        {
            attentionImage.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            meshrenderer.enabled = false;
            boxCollider.enabled = false;
            body.isKinematic = true;
            particleFX.Play();
            Destroy(gameObject, 3f);
        }
    }
}
