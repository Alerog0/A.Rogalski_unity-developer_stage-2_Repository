using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Material mat;
    private Color c1 = new Color(1, 1, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        //mat.SetColor("Albedo", c1);
        Destroy(gameObject, 0.1f);
    }
}
