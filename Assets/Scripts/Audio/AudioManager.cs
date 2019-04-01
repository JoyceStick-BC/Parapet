using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance = null;
    public List<GameObject> collisionD = new List<GameObject>();
    public Queue<GameObject> collisionQueueDebug = new Queue<GameObject>();
    public GameObject _player = null;
    public GameObject ambObj;
    private GameObject multiQuil;

    private float timeOfQuilCol = 0;
    private int numberOfQuilCol = 0;

    private uint bankID;

    public enum flags
    {
        tentFlag,
        mainFlag
    }

    public enum bowlingBallColSurface
    {
        wood,
        stone,
        fabric,
        metal,
        quil
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        AudioInitialisation();
    }
    private void Start()
    {
        foreach (GameObject g in collisionD)
        {
            collisionQueueDebug.Enqueue(g);
        }
        multiQuil = GameObject.Find("MultiQuilSource");
        //AkSoundEngine.RegisterPluginDLL
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
        AkSoundEngine.PostEvent("Parapet_sfx_ambiance", ambObj);
    }

    private void sfx_startSeagul()
    {
        StartCoroutine(sfx_SeagulGen());
    }

    private IEnumerator sfx_SeagulGen()
    {
        RandomBurst();
        AkSoundEngine.PostEvent("Parapet_sfx_seagul", ambObj);
        yield return new WaitForSecondsRealtime(Random.Range(1, 5));
        StartCoroutine(sfx_SeagulGen());
    }

    private void RandomBurst()
    {
        if (Random.Range(0, 100) > 70) AkSoundEngine.SetSwitch("Seagul", "Seagul_Burst", ambObj);
        else AkSoundEngine.SetSwitch("Seagul", "Seagul_Single", ambObj);
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

    public void SplashSound (GameObject splashObj, WaterTriggerManager.waterSplashSize splashSize)
    {
        switch (splashSize)
        {
            case (WaterTriggerManager.waterSplashSize.big):
                AkSoundEngine.SetSwitch("WaterSplash", "big", splashObj);
                break;
            case (WaterTriggerManager.waterSplashSize.medium):
                AkSoundEngine.SetSwitch("WaterSplash", "med", splashObj);
                break;
            case (WaterTriggerManager.waterSplashSize.small):
                AkSoundEngine.SetSwitch("WaterSplash", "small", splashObj);
                break;
        }
        AkSoundEngine.PostEvent("Play_Splash", splashObj);
    }

    //Collision SHIT
    public void BowlingCollision(Collision collision, bowlingBallColSurface surfaceCollided)
    {
        GameObject placeholder = collisionQueueDebug.Dequeue();
        placeholder.transform.position = collision.contacts[0].point;
        collisionQueueDebug.Enqueue(placeholder);
        switch (surfaceCollided)
        {
            case (bowlingBallColSurface.fabric):
                AkSoundEngine.SetSwitch("BowlingBallCol", "fabric", placeholder);
                break;
            case (bowlingBallColSurface.metal):
                AkSoundEngine.SetSwitch("BowlingBallCol", "metal", placeholder);
                break;
            case (bowlingBallColSurface.quil):
                AkSoundEngine.SetSwitch("Quil_Col", "single", placeholder);
                AkSoundEngine.SetSwitch("BowlingBallCol", "quil", placeholder);
                break;
            case (bowlingBallColSurface.stone):
                AkSoundEngine.SetSwitch("BowlingBallCol", "stone", placeholder);
                break;
            case (bowlingBallColSurface.wood):
                AkSoundEngine.SetSwitch("BowlingBallCol", "wood", placeholder);
                break;
        }

        AkSoundEngine.PostEvent("Play_BBCol", placeholder);
    }

    private float ballVelocity = 0;
    public void QuilCount (Collision collision)
    {
        print("quil count");
        numberOfQuilCol++;
        if (collision.relativeVelocity.magnitude > ballVelocity) ballVelocity = collision.relativeVelocity.magnitude;
        if (ballVelocity > 3 && numberOfQuilCol > 4)
        {
            AkSoundEngine.PostEvent("Play_quil_mult", multiQuil);
        }
        StopCoroutine(quilTimer());
        StartCoroutine(quilTimer());
    }

    IEnumerator quilTimer ()
    {
        yield return new WaitForSecondsRealtime(.5f);
        Debug.Log("TRIGG");
        numberOfQuilCol = 0;
        ballVelocity = 0;
    }

    public void SetOcclusion (float obstrLvl, float occlusionLevel, GameObject objectToOcc)
    {
        AkSoundEngine.SetObjectObstructionAndOcclusion(objectToOcc, _player, obstrLvl, occlusionLevel);
        //AkSoundEngine.SetObjectObstructionAndOcclusion(objectToOcc, _player, 0, 0);
    }

    public void SetOcclusionRTPC (float value, GameObject target)
    {
        AkSoundEngine.SetRTPCValue("Occlusion", value, target);
    }

    public void SetOcclusionAmb (float value)
    {
        AkSoundEngine.SetRTPCValue("AmbianceOC", value);
    }

    public void PlayMiniCannon (GameObject miniCannon)
    {
        AkSoundEngine.PostEvent("Play_NewMort", miniCannon);
    }
    public void PlayBalloonRelease (GameObject gameObj)
    {
        AkSoundEngine.PostEvent("Play_BalloonRelease", gameObj);
    }

    public void PlayQuilRez ()
    {
        AkSoundEngine.PostEvent("Play_Rez", multiQuil);
    }
    public void PlayButton (GameObject button)
    {
        AkSoundEngine.PostEvent("Play_Para_Button", button);
    }

}
