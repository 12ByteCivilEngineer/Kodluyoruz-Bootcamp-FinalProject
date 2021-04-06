using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    public GameObject apartment;
    RotateInput rotateInput;
    float rotateAngle;
    float rotateSpeed = 10f;

    private void Start()
    {
        rotateInput = FindObjectOfType<RotateInput>();
        string apartmentTag = apartment.tag;
        switch (apartmentTag)
        {
            case "four":
                rotateAngle = 90f;
                break;
            case "five":
                rotateAngle = 108f;
                break;
            case "six":
                rotateAngle = 120f;
                break;
            case "seven":
                rotateAngle = 128f;
                break;
            case "eight":
                rotateAngle = 45f;
                break;
        }
    }

    private void Update()
    {
        RotateApartment();
    }

    void RotateApartment()
    {

        rotateInput.Swipe();


        if (rotateInput.direction == "left")
        {
            apartment.transform.DORotate( new Vector3(0f, - rotateAngle, 0f) , 2f, RotateMode.WorldAxisAdd);
            rotateInput.direction = "none";
        }
        if (rotateInput.direction == "right")
        {
            apartment.transform.DORotate(new Vector3(0f, rotateAngle, 0f), 2f, RotateMode.WorldAxisAdd);
            rotateInput.direction = "none";
        }
    }

}
