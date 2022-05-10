using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject theGun;
    public GameObject muzzleFlash;
    public AudioSource gunFire, emptySound;
    public bool isFiring = false;
    public float targetDistance;
    public int damageAmount = 5;
    public float fireRate;
    public string fireAnim;
    public GameObject gunImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(GlobaAmmo.handgunAmmo < 1)
            {
                emptySound.Play();
            }
            else
            {
                if (isFiring == false)
                {
                    StartCoroutine(FiringHandgun());
                }
            }
        }
    }

    IEnumerator FiringHandgun()
    {
        RaycastHit theShot;
        isFiring = true;
        GlobaAmmo.handgunAmmo -= 1;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))
        {
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        theGun.GetComponent<Animator>().Play(fireAnim);
        muzzleFlash.SetActive(true);
        gunFire.Play();

        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(fireRate);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
