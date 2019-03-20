using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Explode : MonoBehaviour {
    int radius = 10;
    int power = 400;
    public GameObject NelsonBase;
    public GameObject NelsonBottom;
    public GameObject NelsonMiddle;
    public GameObject NelsonTop;

    private bool exploded = false;


    // Use this for initialization
    void Start()
    {
        NelsonBase.GetComponent<Rigidbody>().isKinematic = true;
        NelsonBottom.GetComponent<Rigidbody>().isKinematic = true;
        NelsonMiddle.GetComponent<Rigidbody>().isKinematic = true;
        NelsonTop.GetComponent<Rigidbody>().isKinematic = true;

        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.Log("very sad");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(ExplodePiller);
    }

    private void ExplodePiller(object sender, InteractableObjectEventArgs e)
    {
        if (!exploded)
        {
            NelsonBase.GetComponent<Rigidbody>().isKinematic = false;
            NelsonBottom.GetComponent<Rigidbody>().isKinematic = false;
            NelsonMiddle.GetComponent<Rigidbody>().isKinematic = false;
            NelsonTop.GetComponent<Rigidbody>().isKinematic = false;

            Vector3 explosionPos = transform.position;

            explosionPos.x = explosionPos.x + 5;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
            exploded = true;
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
