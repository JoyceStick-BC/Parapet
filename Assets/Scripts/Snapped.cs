using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Snapped : MonoBehaviour {

    public GameObject snapped;
    private bool done = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!done)
        {
            if (gameObject.transform.position.Equals(snapped.transform.position))
            {
                VRTK_Logger.Info("Snapped");
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponent<MeshCollider>());
                done = true;
            }
        }
	}
}
