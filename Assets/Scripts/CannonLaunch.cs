using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class CannonLaunch : MonoBehaviour {

    //cannonball variables
    public GameObject cannonball;
    Rigidbody cannonballRB; 
    public Transform shotPos;
    public GameObject explosion;
    public int firepower;
	// Use this for initialization
	void Start () {
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            VRTK_Logger.Info("No Interactable Script");
        }

        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(Mortar_InteractableObjectUsed);

    }
    private void Mortar_InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        AudioManager.Instance.PlayMortar(gameObject);
        GameObject cannonballCopy = Instantiate(cannonball, shotPos.position, shotPos.rotation) as GameObject;
        //GameObject cannonballCopy = Instantiate(cannonball, shotPos.position, cannonball.transform.rotation) as GameObject;
        cannonballRB = cannonballCopy.GetComponent<Rigidbody>();
        //cannonballRB.AddForce(shotPos.forward * firepower);
        cannonballRB.AddForce(firepower, firepower, 0,ForceMode.Impulse);
        Instantiate(explosion, shotPos.position, shotPos.rotation);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
