using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class PinReset : MonoBehaviour {
    public GameObject[] pins;
    public GameObject[] pinsspawn;
    private GameObject[] pinscopy = new GameObject[10];

    public GameObject SkittlePrebaf;
    private GameObject currentSkittle;
    // Use this for initialization
    void Start () {
        currentSkittle = Instantiate(SkittlePrebaf);
        for (int i = 0; i < pins.Length; i++)
        {
            pinscopy[i] = pins[i];
            //VRTK_Logger.Info("pinscopy: " + pinscopy[i].transform.position.ToString());

        }
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.Log("very sad");
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += new InteractableObjectEventHandler(ResetPins);
    }

    private void ResetPins(object sender, InteractableObjectEventArgs e)
    {
        VRTK_Logger.Info("Clicked Typewriter");
        Destroy(currentSkittle);
        currentSkittle = Instantiate(SkittlePrebaf);
        // If the used object is the typewriter, set the headlines active
        //for (int i = 0; i < pins.Length; i++){
        //    Destroy(pins[i]);

        //    GameObject clone = Instantiate(pinsspawn[i], GameObject.Find("Skittles_geo " + i).transform);
        //    clone.GetComponent<MeshRenderer>().enabled = true;
        //    clone.GetComponent<MeshCollider>().enabled = true;
        //    clone.GetComponent<Rigidbody>().isKinematic = false;
        //    clone.GetComponent<Rigidbody>().useGravity = true;
        //    pins[i] = clone;
        //}

    }
    // Update is called once per frame
    void Update () {
		
	}
}
