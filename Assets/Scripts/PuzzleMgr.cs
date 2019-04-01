using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMgr : MonoBehaviour {

    public int completedPieces;
    private MeshRenderer[] meshes;
    private bool destroyed = false;


    // Use this for initialization
    void Start () {
        completedPieces = 0;
        meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (completedPieces == 12)
        {
            if (!destroyed)
            {
                //play noise and destroy pieces and replace with completed puzzle
                //foreach(MeshRenderer m in meshes)
                //{
                //    m.enabled = false;
                //}
                destroyed = true;
            }
            
        }
	}
}
