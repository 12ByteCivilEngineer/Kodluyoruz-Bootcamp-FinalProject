using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    Rigidbody[] bodies;

    public GameObject player1;
    public GameObject girisPosition1;
    public GameObject cikisPosition1;

    GameObject collidingObject;

    public GameObject apartment;

    bool isrotated = true;
    bool oynadı = true;
    bool isInside = false;
    bool isAnimEnded = false;
    Transform enterPortal;

    private void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        collidingObject = null;
    }   

    private void Update()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ExitAnimations") && !isAnimEnded)
        {
            isAnimEnded = true;
            Debug.Log("exit portal");
            StartRagdollStyleClimbing();
        }
        if (isInside&isrotated)
        {
            anim.enabled = false;
            //apartment.transform.DORotate(new Vector3(0f, 45f, 0f), 2f, RotateMode.LocalAxisAdd);
            float seconds = Mathf.Abs(GetAngleDiff()) / 45f;
            apartment.transform.DORotate(new Vector3(0f, GetAngleDiff(), 0f), seconds , RotateMode.LocalAxisAdd);
            StartCoroutine(ExitPortal(seconds));

            isrotated = false;
            //Invoke("Check",2.1f);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Finish")&oynadı)
        {
            //Debug.Log(gameObject.transform.position.z);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            isInside = true;
            oynadı = false;
        }

    }

    private float GetAngleDiff()
    {
        float angleDiff = GetExitPortal().transform.eulerAngles.y - enterPortal.eulerAngles.y;
        Debug.Log(angleDiff);
        return angleDiff;
    }

    private Transform GetExitPortal()
    {
        int siblingIndex = 0;
        int childIndex = enterPortal.GetSiblingIndex();
        if (childIndex == 0) { siblingIndex = 1; }
        Transform exitPortal = enterPortal.parent.transform.GetChild(siblingIndex);
        return exitPortal;
    }

    IEnumerator ExitPortal(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        collidingObject = GetExitPortal().gameObject;
        transform.position = collidingObject.transform.GetChild(1).transform.position;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);
        anim.applyRootMotion = false;
        anim.enabled = true;
        player1.transform.rotation = Quaternion.Euler(0, 180, 0);
        anim.Play("RollContinue");
        isInside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            enterPortal = other.gameObject.transform;
            isAnimEnded = false;
            anim.enabled = true;
            transform.position = other.transform.GetChild(0).transform.position;
            foreach (Rigidbody body in bodies)
            {
                body.transform.Rotate(0, 0, 0);
            }

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
            gameObject.GetComponent<FallControl>().enabled = false;


            player1.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        //if (other.gameObject.CompareTag("ExitBlock") && isInside) 
        //{
        //    collidingObject = other.gameObject;
        //    Debug.Log(other.gameObject.transform.localRotation.eulerAngles.z);
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);

        //    anim.applyRootMotion = false;
        //    anim.enabled = true;
        //    player1.transform.rotation = Quaternion.Euler(0, 180, 0);
        //    anim.Play("RollContinue");
        //    isInside = false;
        //}
    }
    void Check()
    {
        if (collidingObject==null || !collidingObject.gameObject.CompareTag("ExitBlock"))
        {
            isrotated = true;
        }
    }
    void StartRagdollStyleClimbing()
    {
        anim.enabled = false;
        HandCollisionHandler[] handCollisionHandlers = FindObjectsOfType<HandCollisionHandler>();

        foreach (HandCollisionHandler element in handCollisionHandlers)
        {
            element.MinDistance = 0f;
        }
        foreach (Rigidbody element in bodies)
        {
            element.isKinematic = false;
        }

    }
}

