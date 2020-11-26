using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       // rb.AddForce(Vector3.forward * force);
        //rb.Translate(Vector3.forward * sc.force);
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Vector3 _wallNormal = collision.contacts[0].normal;
            Vector3 dir = Vector3.Reflect(rb.velocity, _wallNormal).normalized;

            rb.velocity = dir * sc.force;


        }
    }*/

}
