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
            AudioManager.Instance.SplashSound(other.gameObject, splashSize.splashSize);
        }
        StartCoroutine(DestroyAfter5(other.gameObject));
    }

    IEnumerator DestroyAfter5 (GameObject objToDestroy)
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(objToDestroy);
    }
}
