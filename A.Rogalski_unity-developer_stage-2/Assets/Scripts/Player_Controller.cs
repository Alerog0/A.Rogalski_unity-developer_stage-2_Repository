using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour, IPoolObject
{
    private Animator anim;
    protected Joystick joystick;


    public void OnObjectSpawn()
    {
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        
    }

 
    void Update()
    {
        Rotator();
    }

    public void Die()
    {
        anim.SetTrigger("Death");
        Invoke("Deactivate", 4f);

    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void Rotator()
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.eulerAngles.y + joystick.Horizontal, transform.rotation.z);
    }


}
