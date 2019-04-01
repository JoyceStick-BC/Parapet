using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ReleaseBalloons : MonoBehaviour {

    public GameObject balloonBasket1;
    public GameObject balloonSample;
    public Material[] balloonColors;

    //new Logic
    private GameObject balloon;
    private int maxBallon = 200;
    private Queue<GameObject> balloonQueue = new Queue<GameObject>();
    private GameObject tempGOHolder;
    private Transform spawnTransform;
    private Renderer buttonRend;
    private Material greenButtonMat;
    private Material greyButtonMat;

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
        InitializeBalloon();
        MaterialInit();
    }

    private void MaterialInit()
    {
        buttonRend = GameObject.Find("BalloonButton").GetComponent<Renderer>();
        greenButtonMat = Resources.Load<Material>("Mat/Button_Green");
        greyButtonMat = Resources.Load<Material>("Mat/Button_Silver");
    }
    private void InitializeBalloon ()
    {
        spawnTransform = GameObject.Find("LaunchPoint").transform;//transform of spawn point
        balloon = GameObject.Find("balloon_lo");
        for (int i = 0; i < maxBallon; i++)
        {
            tempGOHolder = Instantiate(balloonSample, balloonBasket1.transform);//creates one
            tempGOHolder.SetActive(false);//inactive
            tempGOHolder.GetComponent<Renderer>().material = balloonColors[Random.Range(0, balloonColors.Length)];//color
            tempGOHolder.transform.position = spawnTransform.position;//set init pos
            balloonQueue.Enqueue(tempGOHolder);//Add to queue
        }
        
    }

    private void NewBalloon ()
    {
        AudioManager.Instance.PlayBalloonRelease(gameObject);
        tempGOHolder = balloonQueue.Dequeue();
        tempGOHolder.transform.position = balloonBasket1.transform.position;
        tempGOHolder.SetActive(true);
        Rigidbody rb = tempGOHolder.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        rb.AddForce(Random.Range(-1, 1) * 1, 4, Random.Range(-1, 1) * 1, ForceMode.Impulse);
        tempGOHolder.GetComponent<MeshRenderer>().enabled = true;
        tempGOHolder.GetComponent<ConstantForce>().enabled = true;
        tempGOHolder.GetComponent<MeshCollider>().enabled = true;
        //SetForce
        balloonQueue.Enqueue(tempGOHolder);

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
            //    
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
            NewBalloon();
            buttonRend.material = greenButtonMat;
            buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.039f, 0);
        }
        else
        {
            buttonRend.material = greyButtonMat;
            buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.006914731f, 0);
        }

    }
}
