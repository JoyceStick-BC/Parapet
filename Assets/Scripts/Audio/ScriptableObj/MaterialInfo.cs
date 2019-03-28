using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Behaviours/Materials")]
public class MaterialInfo : ScriptableObject {
    public CollisionManager.collisionMaterials objectsMaterial;
    public GameObject objectToInstantiate;
    private GameObject objectToPlayFrom;
    public int objectHardness;
    private string switchGroupName = "Materials";

    public void OnCollisionLogic (Collision collision, MaterialInfo collidedMaterialInfo)
    {
        if (collidedMaterialInfo.objectHardness > objectHardness)
        {
            if (collision.contacts.Length > 3)
            {
                objectToPlayFrom = Instantiate(objectToInstantiate);
                objectToPlayFrom.transform.position = collision.contacts[0].point;
                AudioManager.Instance.sfx_MultipleImpacts(objectToPlayFrom);
                //AudioManager.Instance.DestroyAfter5Sec(objectToPlayFrom);
            }
            //else AudioManager.Instance
        }
        else if (collidedMaterialInfo.objectHardness == objectHardness && CollisionManager.Instance.ThisGameObjectWillPlayTheSound())
        {
            if (collision.contacts.Length > 3)
            {
                //AudioManager.Instance
            }
            //else AudioManager.Instance
        }
    }

    public void TestCo ()
    {
        objectToPlayFrom = Instantiate(objectToInstantiate);
        AudioManager.Instance.DestroyAfter5Sec(objectToPlayFrom);
    }


}
