using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JetpackControl : MonoBehaviour
{
    public GameObject[] hands;
    public float flyTime = 10;
    HandsMovementController handMovementController;

    [SerializeField]
    GameObject jetpack;
    float time;


    private void Start()
    {
        jetpack.SetActive(false);
        handMovementController = FindObjectOfType<HandsMovementController>();
    }

    private void Update()
    {
        if (time > 0)
        {
            ActivateJetpack();
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            InActivateJetpack();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jetpack")
        {
            time = flyTime;
            Destroy(other.gameObject);
        }
    }

    void ActivateJetpack()
    {
        FlyControl.FlyStatu = true;
            jetpack.SetActive(true);
        Fly();
    }

    void InActivateJetpack()
    {
        FlyControl.FlyStatu = false;
        jetpack.SetActive(false);

    }
    public void Fly()
    {
        Vector3 leftHand = hands[0].transform.position + new Vector3(0f, 5f, 0f);
        Vector3 righttHand = hands[1].transform.position + new Vector3(0f, 5f, 0f);
        Vector3 handMatcher = new Vector3(righttHand.x, leftHand.y, righttHand.z);

        hands[0].transform.DOMove(leftHand, 1f);
        hands[1].transform.DOMove(handMatcher, 1f);
        HandsMovementController.isLeft = true;
    }
}
