using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Rigidbody rb;
    private Animator anim;
    Rigidbody[] bodies;

    private void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            anim.enabled = true;
            HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();
            anim.SetBool("isColliding", true);
            foreach (HandCollisionHandler element in handCollisionHandlers)
            {
                element.MinDistance = Mathf.Infinity;
            }
            foreach (Rigidbody element in bodies)
            {
                element.isKinematic = true;
            }
        }
    }
}
