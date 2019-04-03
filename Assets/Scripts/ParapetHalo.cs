using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParapetHalo : MonoBehaviour
{
    public float slow = 2;
    public double size;
    public GameObject halo;
    // Use this for initialization
    void Start()
    {
        //public GameObject typewriterhalo = GameObject.Find("halo");
        //Component hinge = typewriterhalo.GetComponent("Halo")
    }

    // Update is called once per frame
    void Update()
    {
        double pulse = Mathf.Abs(Mathf.Sin(Time.fixedTime / slow * Mathf.PI)) * size + .1;
        Light objectLight = halo.GetComponent<Light>();
        objectLight.range = (float)pulse;
    }
}