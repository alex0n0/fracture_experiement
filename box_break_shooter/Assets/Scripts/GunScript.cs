using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 10f;//the smaller the number, the larget the wait

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    private float nextTimeToFire = 0f;

    void Update()
    {
        //GetButtonDown for clicks
        //GetButton for autofire
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            //Time.time is current time
            //1f / fireRate + current time gives the next allowable time for firing
            Shoot();

        }
    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        //origin of shot, direction of shit, where to save information, input range
        {
            Debug.Log(hit.transform.name);

            TargetScript target = hit.transform.GetComponent<TargetScript>();
            //create instance of TargetScript from the component
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
                //test that the RaycastHit object has a rigidbody
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                //hit.normal is perpendicular to face. we need force to go into face thus negative
            }
            
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

//            GameObject impactEffectObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    //create reference to instantiated object through GameObject
//            Destroy(impactEffectObject, 2f);
    //delete the GameObject after 2 float seconds

        }

    }

}
