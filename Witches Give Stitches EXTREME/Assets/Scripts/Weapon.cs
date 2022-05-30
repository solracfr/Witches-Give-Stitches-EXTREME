using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    
    // this is for the hit effect from the weapon
    // we choose it to be a GameObject bc we 
    // plan to instantiate it
    [SerializeField] GameObject hitEffect;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    private void OnEnable() 
    {
        canShoot = true; // allows for immediate shooting after weapon switching; known bug with this where you can reset the delay by switching weapons
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit; // stores info about the raycast hit
        bool hitSuccessful = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        if (hitSuccessful) // we hit something!
        {
            //Debug.Log($"You have hit {hit.transform.name}"); // print out what's been hit
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            //if we shot something other than an enemy
            if (target == null) { return; }

            //call a method on EnemyHealth that decreases the enemy's health
            target.TakeDamage(weaponDamage);
        }
        else // we didn't connect with anything (i.e. shot at the sky or something)
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        // Below: what i came up with
        //Instantiate(hitEffect, hit.transform.position, Quaternion.identity);

        // hit.point is impact space where collider was struck
        // hit.normal is the normal of the surface the ray hit
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
