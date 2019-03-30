using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance = null;

    private uint bankID;

    public enum flags
    {
        tentFlag,
        mainFlag
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        AudioInitialisation();
    }
    private void Start()
    {
        AkSoundEngine.RegisterPluginDLL
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
        AkSoundEngine.LoadBank("Main_02", AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
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


    public void sfx_MultipleImpacts (GameObject collisionObj)
    {
        AkSoundEngine.SetSwitch("Seagul", "Seagul_Burst", collisionObj);
    }
    public void sfx_SingleImpacts(GameObject collisionObj)
    {
        AkSoundEngine.SetSwitch("Seagul", "Seagul_Single", collisionObj);
    }

    public void sfx_SetMaterialSwitch (string switchName, string switchGroupName, GameObject collisionObj)
    {
        AkSoundEngine.SetSwitch(switchGroupName, switchName, collisionObj);
    }

    public void DestroyAfter5Sec (GameObject objectToDestroy)
    {
        StartCoroutine(DestroyAfter5Corountine(objectToDestroy));
    }
    IEnumerator DestroyAfter5Corountine(GameObject objectToDestroy)
    {
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("Destroy");
        Destroy(objectToDestroy);
    }

    public void PlayMortar (GameObject mortarObj)
    {
        AkSoundEngine.PostEvent("Play_Parapet_sfx_mort", mortarObj);
    }
    public void PlayMainFlag(GameObject mainFlagObj)
    {
        AkSoundEngine.PostEvent("Play_Parapet_sfx_mainFlag", mainFlagObj);
    }
    public void PlaySecondaryFlags(GameObject lineOfFlagsObj)
    {
        AkSoundEngine.PostEvent("Play_MXG_Para_sfx_flag_multi", lineOfFlagsObj);
    }

    public void PlayTowerDestruction (GameObject tower)
    {
        AkSoundEngine.PostEvent("Play_Parapet_TowerExplosion", tower);
    }

    public void PlayPuzzleSnapSound (GameObject puzzlePiece)
    {
        AkSoundEngine.PostEvent("Play_Parapet_sfx_puzzlePiece", puzzlePiece);
    }
    public void PlayPuzzleCompleteSound(GameObject puzzlePiece)
    {
        AkSoundEngine.PostEvent("Play_Parapet_sfx_puzzleComplete", puzzlePiece);
    }

    public void PinResetSound ()
    {
        //AkSoundEngine.PostEvent("", );
    }

    //Find Bowling Bowl so that it plays in 3D
    //Add a collision for bowl in water
    public void BowlingBowlSpawn (GameObject spawnBowl)
    {
        AkSoundEngine.PostEvent("Play_BallRespawn", gameObject);
    }

    public void BowlingBowlGrab (GameObject ball)
    {
        AkSoundEngine.PostEvent("Play_BallGrab", ball );
    }

    public void JackInTheBox (GameObject jackObj)
    {
        AkSoundEngine.PostEvent("Play_JackInTheBox", jackObj);
    }

    public void PlayTentFlag(GameObject tentFlag)
    {
        //AkSoundEngine.PostEvent("Play_Parapet_sfx_tentFlag", tentFlag);
    }

    public void UpdateBallAngularRTPC (float angularV, GameObject ball)
    {
        AkSoundEngine.SetRTPCValue("ballAngularV", angularV, ball);
    }

    public void PlayRollingBall(GameObject ball)
    {
        AkSoundEngine.PostEvent("Play_Roll", ball);
    }
    public void StopRollingBall(GameObject ball)
    {
        AkSoundEngine.PostEvent("Stop_Roll", ball);
    }
}
