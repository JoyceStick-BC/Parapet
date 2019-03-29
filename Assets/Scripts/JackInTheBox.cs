using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class JackInTheBox : MonoBehaviour {
    public GameObject trigger;
    public Animator myAnimationController;

	// Use this for initialization
	void Start () {
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.Log("very sad");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += new InteractableObjectEventHandler(TriggerAnimation);
    }

    private void TriggerAnimation(object sender, InteractableObjectEventArgs e)
    {
        //myAnimationController.SetBool("playanim", true);
        myAnimationController.Play("Take 001");
    }


    // Update is called once per frame
    void Update () {
		
	}
}
