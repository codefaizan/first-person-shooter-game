using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    //public GameObject impactEffect;
    
    public float range = 100f;
    public float damage = 10f;
    public float force = 40f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            shoot();

            GameObject bulletClone = Instantiate(bullet, bulletSpawnPoint);
            Vector3 moveBullet = bulletClone.transform.forward * 1.2f;
            bulletClone.transform.forward = moveBullet;
            //Destroy(bulletClone, 0.7f);
        }
    }

    void shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            target target = hit.transform.GetComponent<target>();
            if(target != null)
            {
                target.getDamage(damage);
            }
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }

            
            //GameObject impactGO =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactGO, 0.7f);
        }
        
    }
}
