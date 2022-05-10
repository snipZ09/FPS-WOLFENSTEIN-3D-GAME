using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGunPickup : MonoBehaviour
{
    public static HandGunPickup instance;
    public GameObject realHandgun;
    public GameObject pickupHandgun;
    public AudioSource handgunPickupSound;
    public GameObject pickUpDisplay;
    public GameObject pistolImage;
    public string pickupNote;

    private void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        realHandgun.SetActive(true);
        pickupHandgun.SetActive(false);
        handgunPickupSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = pickupNote;
        pickUpDisplay.SetActive(true);
        GlobalGun.instance.availableGuns.Add(realHandgun);
        GlobalGun.instance.currentGun = GlobalGun.instance.availableGuns.Count - 1;
        GlobalGun.instance.SwitchGun();
    }
}
