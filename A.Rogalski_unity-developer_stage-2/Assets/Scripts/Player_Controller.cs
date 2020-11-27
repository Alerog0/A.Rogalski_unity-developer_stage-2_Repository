using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private Ray_Caster rc;
    private Camera main_Camera;
    private float rotation;
    [SerializeField] private VariableJoystick variableJoystick;

    private float rotateVertical;
    private float rotateHorizontal;
    private Vector2 beginTouchPosition;
    private Vector2 endTouchPosition;
    private Touch touch;

    private float clickStart;
    private bool moreThenOne;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        main_Camera = FindObjectOfType<Camera>();
        rotation = transform.eulerAngles.y;
    }

 
    void Update()
    {
        Rotator();
    }

    public void Die()
    {
        anim.SetTrigger("Death");
        Destroy(gameObject, 4f);
        
    }

    private void Rotator()
    {
        rotation = rotation + variableJoystick.Horizontal;
        print(rotation);
        transform.localRotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z);
       
    }
}
