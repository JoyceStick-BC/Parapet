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

    private Renderer buttonRend;
    private Material greenButtonMat;
    private Material greyButtonMat;

    private void MaterialInit()
    {
        buttonRend = GameObject.Find("ResetButton").GetComponent<Renderer>();
        greenButtonMat = Resources.Load<Material>("Mat/Button_Green");
        greyButtonMat = Resources.Load<Material>("Mat/Button_Silver");
    }

    // Use this for initialization
    void Start () {
        MaterialInit();
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
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += new InteractableObjectEventHandler(ResetPins);
    }

    private void ResetPins(object sender, InteractableObjectEventArgs e)
    {
        VRTK_Logger.Info("Clicked Typewriter");
        Destroy(currentSkittle);
        currentSkittle = Instantiate(SkittlePrebaf);
        AudioManager.Instance.PinResetSound();
        StartCoroutine(ButtonToGreen());

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
    IEnumerator ButtonToGreen()
    {
        AudioManager.Instance.PlayButton(gameObject);
        AudioManager.Instance.PlayQuilRez();
        buttonRend.material = greenButtonMat;
        buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.039f, 0);
        yield return new WaitForSecondsRealtime(.15f);
        buttonRend.gameObject.transform.localPosition = new Vector3(0, -0.006914731f, 0);
        buttonRend.material = greyButtonMat;
    }
}
