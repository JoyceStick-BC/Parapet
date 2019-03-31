using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ReleaseBalloons : MonoBehaviour {

    public GameObject balloonBasket1;
    public GameObject balloonSample;

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
                rb.AddForce(Random.Range(-1, 1) * 1, 4, Random.Range(-1, 1) * 1, ForceMode.Impulse);
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
        totalBallons = balloonBasket1.transform.childCount;
        Transform[] transforms = balloonBasket1.GetComponentsInChildren<Transform>();
        print("balloons = " + transforms.Length);
        foreach(Transform t in transforms)
        {
            if (t.position.y > 200)
            {
                Destroy(t.gameObject);
            }
        }
        if (transforms.Length < 500)
        {
            GameObject clone = Instantiate(balloonSample, balloonBasket1.transform);
            clone.GetComponent<Rigidbody>().isKinematic = false;
            clone.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1) * 1, 4, Random.Range(-1, 1) * 1, ForceMode.Impulse);
            clone.GetComponent<MeshRenderer>().enabled = true;
            clone.GetComponent<ConstantForce>().enabled = true;
        }
    }
}
