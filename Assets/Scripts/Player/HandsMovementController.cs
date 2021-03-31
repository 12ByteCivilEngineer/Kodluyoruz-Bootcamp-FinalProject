using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandsMovementController : MonoBehaviour
{
    GameManager gameManager;
    public HandControl handControl;
    [SerializeField] GameObject[] hands;
    public float moveTime = 1f;
    [SerializeField] float forceCoefficient = 1f;
    [SerializeField] float maxAllowedHandGap = 2.47f;
    GameObject collisionDetector;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        collisionDetector = FindObjectOfType<HandCollisionDetector>().gameObject;
    }

    public void MoveHand(HandControl handType,float force, Vector3 position)
    {
        int i;
        if (handType == HandControl.LEFT) { i = 0; }
        else { i = 1; }
        Vector3 direction = (position - hands[i].transform.position).normalized;
        Vector3 target = hands[i].transform.position + (direction * force * forceCoefficient /Time.timeScale);
        DoDistanceCheck(i,target);
        hands[i].transform.DOMove(target, moveTime);
        collisionDetector.transform.position = target;
    }

    private void DoDistanceCheck(int i, Vector3 target)
    {
        int j = 0;
        if (i==0) { j = 1; }
        float distance = Vector3.Distance(hands[j].transform.position, target);
        if (distance > maxAllowedHandGap)
        {
            gameManager.IsGameLost = true;
            Debug.Log("Too much distance");
        }
    }
}
