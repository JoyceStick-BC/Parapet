using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiQuil : MonoBehaviour {
    private bool down = false;
    private bool alreadyCollided = false;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor" || down || alreadyCollided) return;
        AudioManager.Instance.QuilCount(collision);
        if (alreadyCollided == false)
        {
            StartCoroutine(collidedTimer());
        }

    }

    void Update()
    {
        print(transform.rotation.eulerAngles);
        if ((transform.rotation.eulerAngles.x > 30 && transform.rotation.eulerAngles.x < 340) || (transform.rotation.eulerAngles.z > 30 && transform.rotation.eulerAngles.z < 340))
        {
            print("DOWN");
            down = true;
        }
    }

    IEnumerator collidedTimer ()
    {
        alreadyCollided = true;
        yield return new WaitForSecondsRealtime(1.5f);
        alreadyCollided = false;
    }
}
