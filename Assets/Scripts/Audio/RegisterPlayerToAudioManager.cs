using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPlayerToAudioManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.Instance._player = gameObject;

    }
}
