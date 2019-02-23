using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    public static CollisionManager Instance = null;

    private bool collisionSwitch;//bool used to determine which gameobj is playing sound when hardness are =

    public enum collisionMaterials
    {
        plastic,
        wood,
        metal
    }

    private MaterialHolder[] allMaterialsInGame;
    private MaterialInfo tempMatInfo;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        InitializeMaterials();
    }

    private void InitializeMaterials ()
    {
        allMaterialsInGame = FindObjectsOfType<MaterialHolder>();
        Debug.Log(allMaterialsInGame.Length);
        foreach(MaterialHolder m in allMaterialsInGame)
        {
            tempMatInfo = m.materialInfo;
            Debug.Log("Parapet_sfx_" + tempMatInfo.objectsMaterial.ToString());
            switch (tempMatInfo.objectsMaterial)
            {
                //case (collisionMaterials.metal):
                //    m.objectHardness = 3;
                //    //m.objectID = AkSoundEngine.GetIDFromString("Parapet_sfx_" + m.objectsMaterial.ToString());
                //    break;
                //case (collisionMaterials.wood):
                //    m.objectHardness = 2;
                //    break;
                //case (collisionMaterials.plastic):
                //    m.objectHardness = 1;
                //    break;

            }
        }
    }

    public bool ThisGameObjectWillPlayTheSound()
    {
        collisionSwitch = !collisionSwitch;
        return collisionSwitch;
    }
}
