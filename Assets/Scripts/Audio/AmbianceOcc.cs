using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceOcc : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == AudioManager.Instance._player)
        {
            AudioManager.Instance.SetOcclusionAmb(0);
            //AudioManager.Instance.SetOcclusion(testValue01, testValue02, AudioManager.Instance.ambObj);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == AudioManager.Instance._player)
        {
            AudioManager.Instance.SetOcclusionAmb(100);
            //AudioManager.Instance.SetOcclusion(0, 0, AudioManager.Instance.ambObj);
        }
    }
}
