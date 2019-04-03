using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SnapPiece : MonoBehaviour {

    public GameObject obj;
    private bool done = false;
	// Use this for initialization
	void Start () {

        GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(Snap);
	}


    private void Snap(object sender, SnapDropZoneEventArgs snappedObject)
    {
        if (!done)
        {
            Debug.Log("Snapped a Piece");
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<MeshCollider>());
            obj.GetComponent<PuzzleMgr>().compPieces++;
            done = true;
            AudioManager.Instance.PlayPuzzleSnapSound(gameObject);
            PuzzleMgr.Instance.completedPieces++;
        }
        
    }


    // Update is called once per frame
    void Update () {
		
	}
}
