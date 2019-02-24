using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour {
    public CollisionManager.collisionMaterials collisionMaterial;
    public bool objectIsStatic;
    public MaterialInfo materialInfo;

    //DEBUG SECTION ------
    //public GameObject debugObj;//To DElete
    //private GameObject tempGO;//To Delete
    //private Transform debugTransform;// To DElete
    //---------------------

    private MaterialInfo collidedObjMatInfo;
	// Use this for initialization
	void Awake () {
        materialInfo = Resources.Load<MaterialInfo>("ScriptableObjects/Audio/" + collisionMaterial.ToString());
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contacts.Length);
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            //tempGO = Instantiate(debugObj);
            //tempGO.transform.position = collision.contacts[i].point;
        }
        
        Debug.Log("Relative Velocity = " + collision.relativeVelocity.magnitude);
        if (!objectIsStatic)
        {
            collidedObjMatInfo = collision.gameObject.GetComponent<MaterialHolder>().materialInfo;
            if (collidedObjMatInfo.objectHardness > materialInfo.objectHardness)
            {

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("YO");
            materialInfo.TestCo();
        }
    }
}
