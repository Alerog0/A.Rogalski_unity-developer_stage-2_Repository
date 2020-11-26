using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Animator anim;
    private Material mat;
    private Color c1 = new Color(1, 1, 1, 1);
    [SerializeField] private ParticleSystem deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        //mat.SetColor("Albedo", c1);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        anim.SetTrigger("Death");
        Destroy(gameObject, 4f);
    }
}
