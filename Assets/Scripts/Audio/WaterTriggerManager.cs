using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggerManager : MonoBehaviour {
    public enum waterSplashSize
    {
        big,
        medium,
        small
    }
    public GameObject particlePrefab;
    public GameObject particlePrefab2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "Ocean") return;
        WaterColMat splashSize = other.gameObject.GetComponent<WaterColMat>();
        if (splashSize != null)
        {
            AudioManager.Instance.SplashSound(other.gameObject, splashSize.splashSize);
        }
        StartCoroutine(DestroyAfter5(other.gameObject));
    }

    public int scale;
    IEnumerator DestroyAfter5 (GameObject objToDestroy)
    {
        //part02
        GameObject tempGO;
        tempGO = Instantiate(particlePrefab);
        tempGO.transform.localScale += new Vector3(1, 1, 1) * 0;

        tempGO.transform.position = objToDestroy.transform.position;
        yield return new WaitForSecondsRealtime(5);
        Destroy(objToDestroy);
        Destroy(tempGO);
    }
}
