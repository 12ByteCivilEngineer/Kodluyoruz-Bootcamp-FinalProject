using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInput : MonoBehaviour
{
    float firstPos;
    float lastPos;
    float swipeDirection;
    [HideInInspector] public string direction = "none";

    public void Swipe()
    {


        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPos = Input.mousePosition.x;

            swipeDirection = lastPos - firstPos;

            if (swipeDirection < -50f)
            {
                direction = "left";
            }
            else if (swipeDirection > 50f)
            {
                direction = "right";
            }
            else
            {
                direction = "none";
            }
        }



    }
}
