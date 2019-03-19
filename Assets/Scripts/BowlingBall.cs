using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BowlingBall : MonoBehaviour {
    public GameObject spawn = GameObject.Find("Sphere (1)");
    private Transform t;
    private bool grabbed = false;
    private float elapsed = 1;
    private bool spawned = false;
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
        if (!grabbed)
        {
            elapsed = Time.time;
        }
        grabbed = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update () {
        if (grabbed && !spawned)
        {
            VRTK_Logger.Info("Can spawn");
            if (Time.time - elapsed > 3)
            {
                VRTK_Logger.Info("Spawned" + spawn.transform.position.x + " y: " + spawn.transform.position.y + " z: " + spawn.transform.position.z);
                GameObject clone = Instantiate(spawn);
                clone.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
                clone.GetComponent<Rigidbody>().useGravity = false;
                clone.GetComponent<MeshRenderer>().enabled = true;
                clone.GetComponent<SphereCollider>().enabled = true;
                clone.GetComponent<BowlingBall>().spawn = spawn;
                //clone.transform.position = t.position;
                spawned = true;
                //gameObject.GetComponent<MeshCollider>().isTrigger = false;
            }
        }
        
	}
}
