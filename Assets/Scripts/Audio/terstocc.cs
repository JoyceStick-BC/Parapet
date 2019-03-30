using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terstocc : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AkSoundEngine.PostEvent("Play_Roll", gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
        {
            Debug.Log("OCCLUDE");
            AudioManager.Instance.SetOcclusion(100, .25f, gameObject);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("OCCLUDE");
            AkSoundEngine.SetObjectObstructionAndOcclusion(gameObject, GameObject.Find("Camera (eye)"), 100, 100);
        }
    }
}
