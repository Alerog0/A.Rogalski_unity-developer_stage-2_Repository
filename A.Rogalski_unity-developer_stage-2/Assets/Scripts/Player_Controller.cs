using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Camera main_Camera;
    [SerializeField] private VariableJoystick variableJoystick;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        main_Camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.LookAt(new Vector3(transform.position.x + variableJoystick.Horizontal, transform.position.y, transform.position.z + variableJoystick.Vertical));
    }


}
