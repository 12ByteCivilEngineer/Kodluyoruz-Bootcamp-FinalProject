using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandsMovementController : MonoBehaviour
{
    //public HandType handType;

    public HandControl handControl;
    [SerializeField] GameObject[] hands;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float forceCoefficient = 1f;
    //Rigidbody hand;
    //[SerializeField] float force;

    void Start()
    {
        //hand = GetComponent<Rigidbody>();
    }

    public void HandForce()
    {
        //hand.AddForce(0f, force, 0f, ForceMode.Force);
    }
    public void MoveHand(HandControl handType,float force)
    {
        int i;
        if (handType == HandControl.LEFT) { i = 0; }
        else { i = 1; }
        Vector3 target = new Vector3(hands[i].transform.position.x, hands[i].transform.position.y + force * forceCoefficient, hands[i].transform.position.z);
        hands[i].transform.DOMove(target, moveTime);
    }

}
