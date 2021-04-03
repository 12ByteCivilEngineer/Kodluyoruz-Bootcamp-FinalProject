using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Rigidbody rb;
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();
            anim.SetBool("isColliding", true);
            foreach (HandCollisionHandler element in handCollisionHandlers)
            {
                element.MinDistance = Mathf.Infinity;
            }
        }

       
    }
    
}
