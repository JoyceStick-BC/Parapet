using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance = null;

    private uint bankID;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        AudioInitialisation();
    }

    private void AudioInitialisation ()
    {
        sfx_mainBankLoader();
        sfx_startAmb();
        sfx_startSeagul();
        AkSoundEngine.RenderAudio();
    }

    private void sfx_mainBankLoader()
    {
        AkSoundEngine.LoadBank("Main", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
    }

    public void MX_Start()
    {

    }

    private void sfx_startAmb ()
    {
        AkSoundEngine.PostEvent("Parapet_sfx_ambiance", gameObject);
    }

    private void sfx_startSeagul()
    {
        StartCoroutine(sfx_SeagulGen());
    }

    private IEnumerator sfx_SeagulGen()
    {
        RandomBurst();
        AkSoundEngine.PostEvent("Parapet_sfx_seagul", gameObject);
        yield return new WaitForSecondsRealtime(Random.Range(1, 5));
        StartCoroutine(sfx_SeagulGen());
    }

    private void RandomBurst()
    {
        if (Random.Range(0, 100) > 70) AkSoundEngine.SetSwitch("Seagul", "Seagul_Burst", gameObject);
        else AkSoundEngine.SetSwitch("Seagul", "Seagul_Single", gameObject);
    }
}
