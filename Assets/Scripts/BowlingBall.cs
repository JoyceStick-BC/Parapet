using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BowlingBall : MonoBehaviour {
    public GameObject spawn;
    private Transform t;
    private bool grabbed = false;
    private float elapsed = 1;
    private bool spawned = false;
    private Rigidbody rb;
    private GameObject pedestral;
    private bool isGrounded = false;
	// Use this for initialization
	void Start () {
        pedestral = GameObject.Find("Pedestral");
        spawn = GameObject.Find("Sphere (1)");
        t = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();

        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            VRTK_Logger.Info("No Interactable Script");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(BowlingBallGrab);

    }
    private void OnCollisionEnter(Collision collision)
    {
        BowlingBallCollisionRegistry reg = collision.gameObject.GetComponent<BowlingBallCollisionRegistry>();
        if (collision.gameObject == pedestral || reg == null) return;
        AudioManager.bowlingBallColSurface surface = reg.surface;
        AudioManager.Instance.BowlingCollision(collision, surface);
        //collisionD.transform.position = collision.transform.position;
    }

    private void BowlingBallGrab(object sender, InteractableObjectEventArgs e)
    {
        if (!grabbed)
        {
            elapsed = Time.time;
        }
        grabbed = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        AudioManager.Instance.BowlingBowlGrab(gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (grabbed && !spawned)
        {
            //VRTK_Logger.Info("Can spawn");
            if (Time.time - elapsed > 3)
            {
                VRTK_Logger.Info("Spawned" + spawn.transform.position.x + " y: " + spawn.transform.position.y + " z: " + spawn.transform.position.z);
                GameObject clone = Instantiate(spawn);
                clone.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
                clone.GetComponent<Rigidbody>().useGravity = false;
                clone.GetComponent<MeshRenderer>().enabled = true;
                clone.GetComponent<SphereCollider>().enabled = true;
                clone.GetComponent<BowlingBall>().spawn = spawn;
                AudioManager.Instance.BowlingBowlSpawn(gameObject);
                //clone.transform.position = t.position;
                spawned = true;
                //gameObject.GetComponent<MeshCollider>().isTrigger = false;
            }
        }

        RaycastHit hit;
        float angluarMagnitude = rb.angularVelocity.magnitude;
        AudioManager.Instance.UpdateBallAngularRTPC(angluarMagnitude, gameObject);
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, .5f))
        {
            isGrounded = true;
            if (angluarMagnitude > 3)
            {
                AudioManager.Instance.PlayRollingBall(gameObject);
            }
            else AudioManager.Instance.StopRollingBall(gameObject);
        }
        else isGrounded = false;
        //occ
        RaycastHit hit02;
        if (AudioManager.Instance._player == null) return;
        Debug.DrawRay(transform.position, AudioManager.Instance._player.transform.position - transform.position);
        if (Physics.Raycast(transform.position, AudioManager.Instance._player.transform.position - transform.position, out hit02, 100))
        {
            //debugOBJ.transform.position = hit02.point;
            //Debug.Log(hit02.collider.gameObject.name);
            if (hit02.collider.gameObject == AudioManager.Instance._player)
            {
                AudioManager.Instance.SetOcclusionRTPC(100, gameObject);
                AudioManager.Instance.SetOcclusion(0, 0, gameObject);
            }
            else
            {
                AudioManager.Instance.SetOcclusionRTPC(20, gameObject);
                Debug.Log("WALLLLLLL");
                AudioManager.Instance.SetOcclusion(100, 10f, gameObject);
            }

        }
    }
    public GameObject debugOBJ;
}
