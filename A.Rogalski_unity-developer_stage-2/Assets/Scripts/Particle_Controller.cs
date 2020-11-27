using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Controller : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 1f);
    }
}
