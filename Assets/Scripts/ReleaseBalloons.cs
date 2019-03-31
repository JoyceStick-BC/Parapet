using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ReleaseBalloons : MonoBehaviour {

    public GameObject balloonBasket1;
    
    private Rigidbody[] balloons;
    private MeshRenderer[] renders;

    private bool launched = false;
    
	// Use this for initialization
	void Start () {
        //balloons = balloonBasket1.
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(Release_Balloons);

    }
    private void Release_Balloons(object sender, InteractableObjectEventArgs e)
    {
        balloons = balloonBasket1.GetComponentsInChildren<Rigidbody>();
        renders = balloonBasket1.GetComponentsInChildren<MeshRenderer>();
        foreach (Rigidbody rb in balloons)
        {

        }
        foreach (MeshRenderer mesh in renders)
        {

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
