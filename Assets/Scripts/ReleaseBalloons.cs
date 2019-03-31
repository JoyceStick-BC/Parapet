using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ReleaseBalloons : MonoBehaviour {

    public GameObject balloonBasket1;
    
    private Rigidbody[] balloons;
    private MeshRenderer[] renders;
    private ConstantForce[] forces;

    private bool launched = false;

    private int totalBallons;
    private int i = 0;

	// Use this for initialization
	void Start () {
        //balloons = balloonBasket1.
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(Release_Balloons);

    }
    private void Release_Balloons(object sender, InteractableObjectEventArgs e)
    {
        if (!launched)
        {
            balloons = balloonBasket1.GetComponentsInChildren<Rigidbody>();
            renders = balloonBasket1.GetComponentsInChildren<MeshRenderer>();
            forces = balloonBasket1.GetComponentsInChildren<ConstantForce>();

            foreach (Rigidbody rb in balloons)
            {
                rb.isKinematic = false;
                rb.AddForce(Random.Range(-1, 1) * 2, 5, Random.Range(-1, 1) * 2, ForceMode.Impulse);
            }
            foreach (MeshRenderer mesh in renders)
            {
                //turn on meshes
                Debug.Log("Turn on Balloon meshes");
                mesh.enabled = true;
            }
            foreach (ConstantForce force in forces)
            {
                //apply constant force
                force.enabled = true;
            }
            launched = true;
        }
        
    }

    // Update is called once per frame
    void Update () {
		//while (i < totalBallons)
  //      {
  //          balloons[i].isKinematic = false;
  //          balloons[i].AddForce(Random.Range(-1, 1) * 2, 5, Random.Range(-1, 1) * 2, ForceMode.Impulse);
  //          renders[i].enabled = true;
  //          forces[i].enabled = true;
  //      }
	}
}
