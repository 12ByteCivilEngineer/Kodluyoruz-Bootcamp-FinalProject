using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FallControl : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image gradientColor;
    public GameObject[] hands;
    float time;
    HandsMovementController movementController;

    void Update()
    {

        BreakTime();
    }

    void BreakTime()
    {
        if (!FlyControl.FlyStatu && Pavement.isGameStarted)
        {
            time = time + Time.deltaTime;
            if (Input.GetButton("Fire1"))
            {
                time = 0;
            }

            if (time >= 5)
            {
                Fall(1f);
            }
            Bar(time);
        }
        
    }

    public void Fall(float fallDistance)
    {
        Vector3 leftHand = hands[0].transform.position + new Vector3(0f, -fallDistance, 0f);
        Vector3 righttHand = hands[1].transform.position + new Vector3(0f, -fallDistance, 0f);
        Vector3 handMatcher = new Vector3(righttHand.x, leftHand.y, righttHand.z);
        hands[0].transform.DOMove(leftHand, 1f);
        hands[1].transform.DOMove(handMatcher, 1f);       
        HandsMovementController.isLeft = true;
    }

    void Bar(float sliderTime)
    {
        slider.value = sliderTime;
        gradientColor.color = gradient.Evaluate(slider.normalizedValue);
    }

}
