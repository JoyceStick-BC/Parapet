using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : MonoBehaviour {
    public GameObject Statue;
    public GameObject fullStatue;
    private GameObject placeholderGO;

    private List<Rigidbody> rigidInPrefab = new List<Rigidbody>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Explode();
        }
    }

    void Explode()
    {
        placeholderGO =Instantiate(Statue, gameObject.transform);
        rigidInPrefab.AddRange(placeholderGO.GetComponentsInChildren<Rigidbody>());
        foreach (Rigidbody rb in rigidInPrefab) rb.AddExplosionForce(5000, rb.gameObject.transform.position, 500);
        GetComponent<Rigidbody>().AddExplosionForce(500, gameObject.transform.position, 50);
        Destroy(fullStatue);
    }




}
