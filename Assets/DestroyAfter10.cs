using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter10 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyAftert10());
	}

    IEnumerator DestroyAftert10 ()
    {
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }
}
