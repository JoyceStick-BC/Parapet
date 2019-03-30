using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jackrotate : MonoBehaviour {

    public int count =0;
    private bool played = false;
    public Animator myAnimationController;

    private float min;
    private float max;
    private bool goUp = true;

    // Use this for initialization
    void Start () {
        min = 0;
        max = .1f;
	}
	
	// Update is called once per frame
	void Update () {
        float x = gameObject.transform.eulerAngles.x;
        float x2 = gameObject.transform.rotation.x;
        //Debug.Log("Euler: " + x);
        Debug.Log("min = " + min + ", max = " + max + ", goUp = " + goUp + ", rotation = " + x2);

        if (count > 50)
        {
            if (!played)
            {
                //myAnimationController.PlayInFixedTime("Take 001",-1, 41);
                myAnimationController.Play("Take 001");
                played = true;
                AudioManager.Instance.JackInTheBox(gameObject);
            }
        }
        if (x2 >= min && x2 <= max)
        {
            Debug.Log("Full rotation");
            count++;
            if(max >= .7)
            {
                goUp = false;
            }
            else if (min <= -.7)
            {
                goUp = true;
            }


            if (goUp)
            {
                min += .1f;
                max += .1f;
            }
            else
            {
                min -= 0.1f;
                max -= 0.1f;
            }
        }
	}
}
