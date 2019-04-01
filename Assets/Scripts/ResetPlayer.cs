using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPlayer : MonoBehaviour {

    public GameObject waterfloor;
    public GameObject startPoint;
    public GameObject eyes;
    public GameObject rig;
    private Transform stpt;
	// Use this for initialization
	void Start () {
        stpt = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(rig.transform.position.y < waterfloor.transform.position.y)
        {
            Debug.Log("Reset Pos");
            //rig.transform.position = stpt.position;

            ////rig.transform.position = startPoint.transform.position;
            ////gameObject.transform.position = startPoint.transform.position;
            //gameObject.transform.position = stpt.position;
            //Application.LoadLevel(Application.loadedLevel);

            //Maybe put a you have died screen
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        //Debug.Log("Camera loc = " + eyes.transform.position);
	}
}
