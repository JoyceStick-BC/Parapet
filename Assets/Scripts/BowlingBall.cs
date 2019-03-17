using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BowlingBall : MonoBehaviour {

    private Transform t;
    private


	// Use this for initialization
	void Start () {
        t = gameObject.transform;

        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            VRTK_Logger.Info("No Interactable Script");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(BowlingBallGrab);

    }

    private void BowlingBallGrab(object sender, InteractableObjectEventArgs e)
    {

    }

    // Update is called once per frame
    void Update () {
        gameObject.transform.position = t.position;
	}
}
