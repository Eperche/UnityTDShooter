using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
   
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    LineRenderer gunLine;
    float timer;
    public float timeBetweenBullets = 0.15f;    
    float effectsDisplayTime = 0.2f;
    public float range = 100f;

    //Fire() için
   /* public GameObject projectile;
    public Transform shotPoint;*/

    void Start()
    {
        gunLine = GetComponent<LineRenderer>();
    }

     
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
          //  Fire();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
        
    }
    public void DisableEffects()
    {
        gunLine.enabled = false;
       
    }
    /*void Fire()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }*/
    void Shoot()
    {
        timer = 0f;

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        if (Physics.Raycast(shootRay,out shootHit,range))
        {
            gunLine.SetPosition(1, shootHit.point);
            //  Debug.DrawRay(shootRay.origin, shootHit.point, Color.red);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
