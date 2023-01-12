using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    //public GameObject impactEffect;
    
    public float range = 100f;
    public float damage = 10f;
    public float force = 40f;
    public float timeBetweenFires;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            shoot();

        }
    }

    void shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(transform.position, forward, Color.red);
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {

                target.getDamage(damage);

            }
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
            
        }
        
    }
}
