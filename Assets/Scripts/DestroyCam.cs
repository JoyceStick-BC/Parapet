using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyAfter5());
	}

    IEnumerator DestroyAfter5 ()
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }

}
