using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showUI : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("waitForSec");

        }
    }
    IEnumerator waitForSec()
    {
        yield return new WaitForSeconds(7);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
