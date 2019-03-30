using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAudio : MonoBehaviour {
    public AudioManager.flags flagType;

	void Start () {
		switch (flagType)
        {
            case (AudioManager.flags.mainFlag):
                AudioManager.Instance.PlayMainFlag(gameObject);
                break;
            case (AudioManager.flags.tentFlag):
                AudioManager.Instance.PlayTentFlag(gameObject);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
