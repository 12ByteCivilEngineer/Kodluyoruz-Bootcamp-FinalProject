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


    void Update()
    {

        BreakTime();
    }

    void BreakTime()
    {
        time = time + Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            time = 0;
        }

        if (time >= 5)
        {
            Fall();
        }
        Bar(time);
    }

    void Fall()
    {
        Vector3 leftHand = hands[0].transform.position + new Vector3(0f, -1f, 0f);
        Vector3 righttHand = hands[1].transform.position + new Vector3(0f, -1f, 0f);

        hands[0].transform.DOMove(leftHand, 1f);
        hands[1].transform.DOMove(righttHand, 1f);

    }

    void Bar(float sliderTime)
    {
        slider.value = sliderTime;
        gradientColor.color = gradient.Evaluate(slider.normalizedValue);
    }

}
