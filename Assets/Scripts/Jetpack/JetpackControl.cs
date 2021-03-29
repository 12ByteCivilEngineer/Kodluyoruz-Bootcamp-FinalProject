using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackControl : MonoBehaviour
{
    public enum FlyState
    {
        NOTFLYING,
        FLYING
    }

    FlyControl flyControl;
    FlyState flyState;
    GameObject jetpack;

    private void Start()
    {
        flyControl = FindObjectOfType<FlyControl>();
        flyState = FlyState.NOTFLYING;
        jetpack = GameObject.Find("/RagdollCharacter/JetPackEfect");
        jetpack.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jetpack")
        {
            ActivateJetpack();
            Destroy(other.gameObject);
        }
    }

    void ActivateJetpack()
    {
        flyState = FlyState.FLYING;
        jetpack.SetActive(true);
        switch (flyState)
        {
            case FlyState.FLYING:
                flyControl.Fly();
                break;
            case FlyState.NOTFLYING:
                Debug.Log("Uçmuyorsun");
                break;
        }
    }

    void InActivateJetpack()
    {
        flyState = FlyState.NOTFLYING;
        jetpack.SetActive(false);
    }
}
