using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForFinalAnimations : MonoBehaviour
{

    public Rigidbody sousage;
    public Rigidbody thief;
    public Animator animForSouage;
    public Animator animForThief;
    public GameObject vakums;

    [SerializeField]
    ParticleSystem boom;

    private void OnTriggerEnter(Collider other)
    {
        if (vakums.CompareTag("FinalCollider"))
        {
            HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();

            foreach (HandCollisionHandler element in handCollisionHandlers)
            {
                element.MinDistance = Mathf.Infinity;
            }

            animForSouage.Play("FinalClimb");
        }
    }

    void Update()
    {
        if (animForSouage.GetCurrentAnimatorStateInfo(0).IsName("JumpOn"))
        {
            thief.transform.rotation = Quaternion.Euler(0, 80, 0);
        }
        if (animForSouage.GetCurrentAnimatorStateInfo(0).IsName("JumpOn"))
        {
            sousage.transform.rotation = Quaternion.Euler(0, -90, 0);
            animForThief.Play("ReadyToFight");
            boom.Play();
        }

        if (boom.IsAlive(true))
        {
            thief.useGravity = true;
            thief.transform.position = Vector3.MoveTowards(thief.transform.position, thief.transform.position - new Vector3(0, 0, 4), 0.09f);
            Invoke("ScaleCharacter", 2.0f);
        }
        
    }

    void ScaleCharacter()
    {
        sousage.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
