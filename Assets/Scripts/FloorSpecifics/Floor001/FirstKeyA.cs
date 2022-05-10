using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKeyA : MonoBehaviour
{
    public GameObject keyUI;
    public GameObject lookedTrigger;
    public GameObject theKey;

    void OnTriggerEnter(Collider other)
    {
        keyUI.SetActive(true);
        lookedTrigger.SetActive(true);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        theKey.SetActive(false);
    }
}
