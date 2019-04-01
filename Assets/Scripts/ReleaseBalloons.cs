using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ReleaseBalloons : MonoBehaviour {

    public GameObject balloonBasket1;
    public GameObject balloonSample;
    public Material[] balloonColors;

    private Rigidbody[] balloons;
    private MeshRenderer[] renders;
    private ConstantForce[] forces;

    private bool launched = false;

    private int totalBalloons;
    private int i = 0;

    public Animator myAnimationController;
    private bool animationPlayed = false;

    private float countdown = 0.5f;
    private float time;

    // Use this for initialization
    void Start () {
        //balloons = balloonBasket1.
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(Release_Balloons);

    }
    private void Release_Balloons(object sender, InteractableObjectEventArgs e)
    {
        if (!animationPlayed)
        {
            myAnimationController.Play("Take 001");
            animationPlayed = true;
        }

        if (!launched)
        {
            //Debug.Log("Release");
            //balloons = balloonBasket1.GetComponentsInChildren<Rigidbody>();
            //renders = balloonBasket1.GetComponentsInChildren<MeshRenderer>();
            //forces = balloonBasket1.GetComponentsInChildren<ConstantForce>();

            //foreach (Rigidbody rb in balloons)
            //{
            //    rb.isKinematic = false;
            //    rb.AddForce(Random.Range(-1, 1) * 1, 4, Random.Range(-1, 1) * 1, ForceMode.Impulse);
            //}
            //foreach (MeshRenderer mesh in renders)
            //{
            //    //turn on meshes
            //    Debug.Log("Turn on Balloon meshes");
            //    mesh.enabled = true;
            //}
            //foreach (ConstantForce force in forces)
            //{
            //    //apply constant force
            //    force.enabled = true;
            //}
            time = Time.time;
            countdown = 0.5f;
            launched = true;
        }
        else
        {
            launched = false;
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (launched)
        {
            
                totalBalloons = balloonBasket1.transform.childCount;
                Transform[] transforms = balloonBasket1.GetComponentsInChildren<Transform>();
                print("balloons = " + transforms.Length);
                foreach (Transform t in transforms)
                {
                    if (t.position.y > 200)
                    {
                        Destroy(t.gameObject);
                    }
                }
                if (transforms.Length < 500)
                {
                    if (Time.time - time > countdown)
                    {
                        GameObject clone = Instantiate(balloonSample, balloonBasket1.transform);
                        clone.GetComponent<Renderer>().material = balloonColors[Random.Range(0, balloonColors.Length)];
                        clone.transform.position = balloonBasket1.transform.position;
                        clone.GetComponent<Rigidbody>().isKinematic = false;
                        clone.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1) * 0, 3, Random.Range(-1, 1) * 0, ForceMode.Impulse);
                        clone.GetComponent<MeshRenderer>().enabled = true;
                        clone.GetComponent<MeshCollider>().enabled = true;
                        clone.GetComponent<ConstantForce>().enabled = true;
                        AudioManager.Instance.PlayBalloonRelease(gameObject);
                    }
                }
                countdown = 0.3f;
            }
    }
}
