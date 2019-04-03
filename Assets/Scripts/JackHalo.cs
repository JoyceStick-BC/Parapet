using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class JackHalo : MonoBehaviour {

    public GameObject halo;

	// Use this for initialization
	void Start () {
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            VRTK_Logger.Info("No Interactable Script");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(JackGrab);
    }

    private void JackGrab(object sender, InteractableObjectEventArgs e)
    {
        halo.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
