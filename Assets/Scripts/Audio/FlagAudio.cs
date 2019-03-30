using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAudio : MonoBehaviour {
    public AudioManager.flags flagType;
    public GameObject debugOBJ;

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

    public float testval;
    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        Debug.DrawRay(transform.position, AudioManager.Instance._player.transform.position - transform.position);
        if (Physics.Raycast(transform.position, AudioManager.Instance._player.transform.position - transform.position, out hit, 100))
        {
            //debugOBJ.transform.position = hit.point;
            if (hit.collider.gameObject != AudioManager.Instance._player)
            {
                Debug.Log("NO PLAYER");
                AudioManager.Instance.SetOcclusion(100, testval, gameObject);
            }
            else
            {
                Debug.Log("PLAYER");
                AudioManager.Instance.SetOcclusion(0, 0, gameObject);
            }
            
        }
    }
}
