using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioTestSeagul : MonoBehaviour {
    uint bankID;
	// Use this for initialization
	void Start () {
        AkSoundEngine.LoadBank("Main", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
        AkSoundEngine.PostEvent("Parapet_sfx_ambiance", gameObject);
        StartCoroutine(SeagulGen());
	}

    IEnumerator SeagulGen()
    {
        RandomBurst();
        AkSoundEngine.PostEvent("Parapet_sfx_seagul", gameObject);
        yield return new WaitForSecondsRealtime(Random.Range(1, 5));
        StartCoroutine(SeagulGen());
    }

    private void RandomBurst ()
    {
        if (Random.Range(0, 100) > 70) AkSoundEngine.SetSwitch("Seagul", "Seagul_Burst", gameObject);
        else AkSoundEngine.SetSwitch("Seagul", "Seagul_Single", gameObject);
    }
}
