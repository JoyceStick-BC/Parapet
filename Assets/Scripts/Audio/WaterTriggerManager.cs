using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggerManager : MonoBehaviour {
    public enum waterSplashSize
    {
        big,
        medium,
        small
    }

    private void OnTriggerEnter(Collider other)
    {
        WaterColMat splashSize = other.gameObject.GetComponent<WaterColMat>();
        if (splashSize != null)
        {

        }
        //if (collider.Get)
    }
}
