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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        main_Camera = FindObjectOfType<Camera>();
        rotation = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    beginTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:

                    endTouchPosition = touch.position;
                    if(beginTouchPosition == endTouchPosition)
                    {
                        rc.Aiming(transform.position, transform.forward, true);
                    }
                    if(beginTouchPosition != endTouchPosition)
                    {
                        Rotator();
                    }
                    break;

            }
        }

        print(transform.localRotation.y);



        Rotator();
        /*rotation = rotation + variableJoystick.Horizontal;
        print(rotation);
        transform.localRotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z);
        */
        //transform.rotation = Quaternion.Normalize(transform.rotation.x, rotation, transform.rotation.z);
        //rb.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y * 360 + variableJoystick.Horizontal * 360, transform.rotation.z);
        print(variableJoystick.Horizontal * 360);
        

        //transform.LookAt(new Vector3(transform.position.x + variableJoystick.Horizontal, transform.position.y, transform.position.z + variableJoystick.Vertical));
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + variableJoystick.Horizontal * 360, transform.rotation.z);
        
    }

    public void Die()
    {
        anim.SetTrigger("Death");
        Destroy(gameObject, 4f);
        
    }

    private void Rotator()
    {
        //float addrotation = variableJoystick.Horizontal;
        rotation = rotation + variableJoystick.Horizontal;
        print(rotation);
        transform.localRotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z);
       
    }
}
