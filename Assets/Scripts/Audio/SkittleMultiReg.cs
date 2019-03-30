using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkittleMultiReg : MonoBehaviour {
    public GameObject bb01;
    public GameObject bb02;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == bb01 || (collision.gameObject == bb02))
        {
            AudioManager.Instance.QuilCount();
        }
    }
}
