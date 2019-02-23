using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour {
    public CollisionManager.collisionMaterials collisionMaterial;
    public bool objectIsStatic;
    public MaterialInfo materialInfo;

    private MaterialInfo collidedObjMatInfo;
	// Use this for initialization
	void Awake () {
        Debug.Log("ScriptableObjects/Audio/" + collisionMaterial.ToString());
        materialInfo = Resources.Load<MaterialInfo>("ScriptableObjects/Audio/" + collisionMaterial.ToString());
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!objectIsStatic)
        {
            collidedObjMatInfo = collision.gameObject.GetComponent<MaterialHolder>().materialInfo;
            if (collidedObjMatInfo.objectHardness > materialInfo.objectHardness)
            {
                //play our sound

            }
            else if (collidedObjMatInfo.objectHardness == materialInfo.objectHardness)
            {
                if (collision.gameObject.GetComponent<MaterialHolder>().objectIsStatic)
                {
                    //Determine how much to play the sound
                }
                else if (CollisionManager.Instance.ThisGameObjectWillPlayTheSound())
                {
                }
            }
        }
    }
}
