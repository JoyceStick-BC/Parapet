using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMgr : MonoBehaviour {
    public static PuzzleMgr Instance = null;
    public int completedPieces;
    private MeshRenderer[] meshes;
    private bool destroyed = false;
    public int compPieces;
    public MeshRenderer finished;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        completedPieces = 0;
        compPieces = 0;
        meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (completedPieces == 12)
        {
            if (!destroyed)
            {
                AudioManager.Instance.PlayPuzzleCompleteSound(gameObject);
                //play noise and destroy pieces and replace with completed puzzle
                //foreach(MeshRenderer m in meshes)
                //{
                //    m.enabled = false;
                //}
                destroyed = true;
            }
            
        }
        if(compPieces == 12)
        {
            Debug.Log("Completed Puzzle");
            MeshRenderer[] rend = gameObject.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer m in rend)
            {
                m.enabled = false;
            }
            finished.enabled = true;
        }
	}
}
