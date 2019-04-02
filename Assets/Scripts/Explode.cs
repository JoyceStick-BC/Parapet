using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Explode : MonoBehaviour {
    int radius = 15;
    int power = 200;
    public GameObject NelsonBase;
    public GameObject NelsonBottom;
    public GameObject NelsonMiddle;
    public GameObject NelsonTop;
    public GameObject explosion;
    private MeshCollider safetyPane;


    private Renderer buttonRend;
    private Material greenButtonMat;
    private Material greyButtonMat;

    public GameObject originalStatue;
    public GameObject exploStatue;
    private List<Rigidbody> rigidInPrefab = new List<Rigidbody>();

    private bool exploded = false;
    private bool clicked = false;
    private float delay;
    private bool firstTimeClick = false;

    private void MaterialInit()
    {
        buttonRend = GameObject.Find("ExplosionButton").GetComponent<Renderer>();
        greenButtonMat = Resources.Load<Material>("Mat/Button_Green");
        greyButtonMat = Resources.Load<Material>("Mat/Button_Silver");
    }
    // Use this for initialization
    void Start()
    {
        safetyPane = GameObject.Find("SafetyPlane").GetComponent<MeshCollider>();
        NelsonBase.GetComponent<Rigidbody>().isKinematic = true;
        NelsonBottom.GetComponent<Rigidbody>().isKinematic = true;
        NelsonMiddle.GetComponent<Rigidbody>().isKinematic = true;
        NelsonTop.GetComponent<Rigidbody>().isKinematic = true;
        MaterialInit();
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.Log("very sad");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(ExplodePiller);
    }

    private void ExplodePiller(object sender, InteractableObjectEventArgs e)
    {
        clicked = true;
        delay = Time.time;
    }

    // Update is called once per frame
    void Update () {

        if (clicked)
        {
            if (!firstTimeClick)
            {
                firstTimeClick = true;
                AudioManager.Instance.PlayButton(gameObject);
                AudioManager.Instance.PlayTowerDestruction(gameObject);
                buttonRend.material = greenButtonMat;
                buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.039f, 0);
                StartCoroutine(waitfor3secondsbeforeColiderisoff(safetyPane.GetComponent<MeshCollider>()));
                gameObject.GetComponent<MeshCollider>().enabled = false;
            }
        }
	}


    IEnumerator waitfor3secondsbeforeColiderisoff (MeshCollider collider)
    {
        safetyPane.isTrigger = true;
        yield return new WaitForSecondsRealtime(.5f);
        GameObject tempGO;
        tempGO = Instantiate(exploStatue);
        tempGO.transform.position = originalStatue.transform.position;

        rigidInPrefab.AddRange(tempGO.GetComponentsInChildren<Rigidbody>());
        int count = 0;
        foreach (Rigidbody rb in rigidInPrefab)
        {
            //rb.AddExplosionForce(500, rb.gameObject.transform.position, 500);
            rb.AddForce(new Vector3(Random.Range(-3,4), Random.Range(100, 200), Random.Range(100, 6000) * -1));
            if (count % 12 == 0)
            {
                //Instantiate(explosion, rb.transform.position, rb.transform.rotation);
            }
            count++;
        }
        Instantiate(explosion, NelsonBase.transform.position, NelsonBase.transform.rotation);
        Instantiate(explosion, NelsonBottom.transform.position, NelsonBottom.transform.rotation);
        Instantiate(explosion, NelsonMiddle.transform.position, NelsonMiddle.transform.rotation);
        Instantiate(explosion, NelsonTop.transform.position, NelsonTop.transform.rotation);

        //GetComponent<Rigidbody>().AddExplosionForce(500, gameObject.transform.position, 50);
        Destroy(originalStatue);
        collider.isTrigger = true;
        yield return new WaitForSecondsRealtime(10);
        foreach (Rigidbody rb in rigidInPrefab)
        {
            if (rb != null)
            {
                Destroy(rb.gameObject);
            }
        }
        safetyPane.isTrigger = false;
        collider.isTrigger = false;
    }
}
