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
        foreach(MaterialHolder m in allMaterialsInGame)
        {
            tempMatInfo = m.materialInfo;
            switch (tempMatInfo.objectsMaterial)
            {
                case (collisionMaterials.metal):
                    tempMatInfo.objectHardness = 3;
                    break;
                case (collisionMaterials.wood):
                    tempMatInfo.objectHardness = 2;
                    break;
                case (collisionMaterials.plastic):
                    tempMatInfo.objectHardness = 1;
                    break;

            }
        }
    }

    public bool ThisGameObjectWillPlayTheSound()
    {
        collisionSwitch = !collisionSwitch;
        return collisionSwitch;
    }

}
