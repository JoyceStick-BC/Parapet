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
    private GameObject safetyPane;

    private bool exploded = false;
    private bool clicked = false;
    private float delay;
    private bool firstTimeClick = false;

    // Use this for initialization
    void Start()
    {
        safetyPane = GameObject.Find("SafetyPlane");
        NelsonBase.GetComponent<Rigidbody>().isKinematic = true;
        NelsonBottom.GetComponent<Rigidbody>().isKinematic = true;
        NelsonMiddle.GetComponent<Rigidbody>().isKinematic = true;
        NelsonTop.GetComponent<Rigidbody>().isKinematic = true;

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
                AudioManager.Instance.PlayTowerDestruction(gameObject);
            }
            if (Time.time - delay >= .5f)
            {
                if (!exploded)
                {
                    NelsonBase.GetComponent<Rigidbody>().isKinematic = false;
                    NelsonBottom.GetComponent<Rigidbody>().isKinematic = false;
                    NelsonMiddle.GetComponent<Rigidbody>().isKinematic = false;
                    NelsonTop.GetComponent<Rigidbody>().isKinematic = false;

                    Vector3 explosionPos = transform.position;

                    explosionPos.x = explosionPos.x + 5;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                    //foreach (Collider hit in colliders)
                    //{
                    //    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    //    if (rb != null)
                    //    {
                    //        rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    //    }
                    //}
                    NelsonBase.GetComponent<Rigidbody>().AddExplosionForce(power + 200, explosionPos, radius, 3.0F);
                    NelsonBottom.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0F);
                    NelsonMiddle.GetComponent<Rigidbody>().AddExplosionForce(power-100, explosionPos, radius, 3.0F);
                    NelsonTop.GetComponent<Rigidbody>().AddExplosionForce(power - 170, explosionPos, radius, 3.0F);
                    Instantiate(explosion, NelsonBase.transform.position, NelsonBase.transform.rotation);
                    Instantiate(explosion, NelsonBottom.transform.position, NelsonBottom.transform.rotation);
                    Instantiate(explosion, NelsonMiddle.transform.position, NelsonMiddle.transform.rotation);
                    Instantiate(explosion, NelsonTop.transform.position, NelsonTop.transform.rotation);
                    exploded = true;
                    StartCoroutine(waitfor3secondsbeforeColiderisoff(safetyPane.GetComponent<MeshCollider>()));
                }
            }
        }
	}


    IEnumerator waitfor3secondsbeforeColiderisoff (MeshCollider collider)
    {
        collider.isTrigger = true;
        yield return new WaitForSecondsRealtime(10);
        collider.isTrigger = false;
    }
}
