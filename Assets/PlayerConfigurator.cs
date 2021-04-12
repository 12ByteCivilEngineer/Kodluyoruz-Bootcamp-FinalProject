using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfigurator : MonoBehaviour
{
    CharacterJoint[] charJoints;
    [SerializeField] bool enableProjection = true;
    [SerializeField] bool enablePreprocessing = false;
    [SerializeField] float projectionDistance = 0.1f;
    [SerializeField] float projectionAngle = 180f;
    // Start is called before the first frame update
    void Awake()
    {
        charJoints = GetComponentsInChildren<CharacterJoint>();
        foreach(CharacterJoint element in charJoints)
        {
            element.enableProjection = enableProjection;
            element.enablePreprocessing = enablePreprocessing;
            element.projectionDistance = projectionDistance;
            element.projectionAngle = projectionAngle;
        }
    }


}
