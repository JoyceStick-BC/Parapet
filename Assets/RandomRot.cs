using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRot : MonoBehaviour {
    private List<Transform> allDebris = new List<Transform>();
	// Use this for initialization
	void Start () {
        allDebris.AddRange(GetComponentsInChildren<Transform>());
        foreach(Transform t in allDebris)
        {
            t.rotation = Random.rotation;
            t.position = Random.insideUnitSphere * 5;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
