using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    ObjectPooler objectPooler;
    private bool spawnTest = true; //It allows you to call the function once
    public string spawnTag; //Tag of Pool

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        Spawn(spawnTag, transform.position, transform.rotation);
    }

    void Spawn(string tag, Vector3 position, Quaternion rotation)
    {
        if (spawnTest == true)
        {
            objectPooler.SpawnFromPool(spawnTag, position, rotation);
            spawnTest = false;
        }
        
    }



}
