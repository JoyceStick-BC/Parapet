﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BowlingBall : MonoBehaviour {

    private Transform t;
    private bool grabbed = false;


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
        grabbed = true;
        Instantiate(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (!grabbed)
        {
            gameObject.transform.position = t.position;
        }
	}
}
