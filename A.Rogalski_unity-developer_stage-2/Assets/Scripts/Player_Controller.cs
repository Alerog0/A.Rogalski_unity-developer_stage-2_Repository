using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private ParticleSystem deathEffect;
    private Rigidbody rb;
    private Camera main_Camera;
    [SerializeField] private VariableJoystick variableJoystick;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        main_Camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.LookAt(new Vector3(transform.position.x + variableJoystick.Horizontal, transform.position.y, transform.position.z + variableJoystick.Vertical));
    }

    public void Die()
    {
        //mat.SetColor("Albedo", c1);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        anim.SetTrigger("Death");
        Destroy(gameObject, 4f);
        
    }
}
