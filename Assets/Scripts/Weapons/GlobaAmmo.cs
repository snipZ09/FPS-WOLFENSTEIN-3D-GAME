using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobaAmmo : MonoBehaviour
{
    public static int handgunAmmo;
    public GameObject ammoDisplay;

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.GetComponent<Text>().text = "" + handgunAmmo;
    }
}
