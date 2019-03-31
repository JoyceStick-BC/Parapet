using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MiniCannon : MonoBehaviour {

    public GameObject cannonball;
    Rigidbody cannonballRB;
    public Transform shotPos;
    public GameObject explosion;
    public int firepower;

    private bool grabbed;
    private float delay;

    // Use this for initialization
    void Start () {
        grabbed = false;
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            VRTK_Logger.Info("No Interactable Script");
        }

        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(Mortar_InteractableObjectGrabbed);
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(Mortar_InteractableObjectUnGrabbed);

    }
    private void Mortar_InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        delay = Time.time;
        grabbed = true;
        AudioManager.Instance.PlayMiniCannon(gameObject);
        GameObject cannonballCopy = Instantiate(cannonball, shotPos.position, shotPos.rotation) as GameObject;
        //GameObject cannonballCopy = Instantiate(cannonball, shotPos.position, cannonball.transform.rotation) as GameObject;
        cannonballRB = cannonballCopy.GetComponent<Rigidbody>();

        //cannonballRB.AddForce(shotPos.forward * firepower);
        cannonballRB.AddForce(firepower, firepower, 0, ForceMode.VelocityChange);
        //Instantiate(explosion, shotPos.position, shotPos.rotation);
    }
    private void Mortar_InteractableObjectUnGrabbed(object sender, InteractableObjectEventArgs e)
    {
        grabbed = false;
        
    }
    // Update is called once per frame
    void Update () {
        if (grabbed)
        {
            if(Time.time - delay > 0.1)
            {
                AudioManager.Instance.PlayMiniCannon(gameObject);
                GameObject cannonballCopy = Instantiate(cannonball, shotPos.position, shotPos.rotation) as GameObject;
                //GameObject cannonballCopy = Instantiate(cannonball, shotPos.position, cannonball.transform.rotation) as GameObject;
                cannonballRB = cannonballCopy.GetComponent<Rigidbody>();

                //cannonballRB.AddForce(shotPos.forward * firepower);
                cannonballRB.AddForce(firepower, firepower, 0, ForceMode.VelocityChange);
                //Instantiate(explosion, shotPos.position, shotPos.rotation);
                delay = Time.time;
            }
        }
    }
}
