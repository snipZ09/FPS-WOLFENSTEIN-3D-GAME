using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunAmmoPickup : MonoBehaviour
{
    public GameObject pickupAmmoClip;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other)
    {
        pickupAmmoClip.SetActive(false);
        ammoPickupSound.Play();
        GlobaAmmo.handgunAmmo += 100;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "CLIP OF BULLETS";
        pickUpDisplay.SetActive(true);
    }
}
