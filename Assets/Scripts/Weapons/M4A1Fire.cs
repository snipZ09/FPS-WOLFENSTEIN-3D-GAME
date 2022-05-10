using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1Fire : MonoBehaviour
{
    public static M4A1Fire instance;
    public GameObject theGun;
    public ParticleSystem muzzleFlash;
    public AudioSource gunFire, emptySound;
    public bool isFiring = false;
    public float targetDistance;
    public int damageAmount = 5;
    public float fireRate;
    public string fireAnim;
    public GameObject gunImage;
    public GameObject impactEffect;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if (GlobaAmmo.handgunAmmo < 1)
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
        if (Physics.Raycast(transform.position + new Vector3 (1,0,0), transform.TransformDirection(Vector3.forward), out theShot))
        {
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
            Debug.Log(theShot.collider);
            Instantiate(impactEffect, theShot.point, theShot.transform.rotation);
        }
        theGun.GetComponent<Animator>().Play(fireAnim);
        muzzleFlash.Play();
        gunFire.Play();

        yield return new WaitForSeconds(0.1f);
        muzzleFlash.Stop();
        yield return new WaitForSeconds(fireRate);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}
