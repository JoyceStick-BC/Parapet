using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Behaviours/Materials")]
public class MaterialInfo : ScriptableObject {
    public CollisionManager.collisionMaterials objectsMaterial;
    public int objectHardness;
    public uint switchID;
}
