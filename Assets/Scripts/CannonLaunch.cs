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

    private Renderer buttonRend;
    private Material greenButtonMat;
    private Material greyButtonMat;

    private void MaterialInit()
    {
        buttonRend = GameObject.Find("CannonButton").GetComponent<Renderer>();
        greenButtonMat = Resources.Load<Material>("Mat/Button_Green");
        greyButtonMat = Resources.Load<Material>("Mat/Button_Silver");
    }
    // Use this for initialization
    void Start () {
        MaterialInit();
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
        StartCoroutine(ButtonToGreen());
    }

    IEnumerator ButtonToGreen ()
    {
        AudioManager.Instance.PlayButton(gameObject);
        buttonRend.material = greenButtonMat;
        buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.039f, 0);
        yield return new WaitForSecondsRealtime(.15f);
        buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.006914731f, 0);
        buttonRend.material = greyButtonMat;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
