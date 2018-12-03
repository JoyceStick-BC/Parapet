using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    int radius = 10;
    int power = 1000;

    // Use this for initialization
    void Start()
    {
        Vector3 explosionPos = transform.position;
        explosionPos.x = explosionPos.x + 5;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
