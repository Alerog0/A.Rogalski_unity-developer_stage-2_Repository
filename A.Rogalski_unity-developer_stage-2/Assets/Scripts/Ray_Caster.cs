using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Caster : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem deathEffect;
    private LineRenderer lr;

    public int RayCount = 10;  //Count of ray bounces
    private float clickStart;  //Mouse timer varaible

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        anim.SetBool("Aiming", true);

    }

    void Update()
    {
        Aiming(transform.position, transform.forward, false);

        if (Input.GetMouseButtonDown(0))
        {
            clickStart = Time.time;
        }

        if (Input.GetMouseButtonUp(0) &&  Time.time - clickStart <= .2f)
        {
            anim.SetTrigger("Attack");
            Aiming(transform.position, transform.forward, true);
        }


    }

    public void Aiming(Vector3 position, Vector3 direction, bool kill)
    {

        lr.SetPosition(0, transform.position);
        
        
        for (int i = 0; i < RayCount; i++)
        {
            lr.positionCount++;
            Ray ray = new Ray(position, direction);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, 10, 1))
            {

                if (hit.collider.CompareTag("Player"))
                {
                    lr.SetPosition(i + 1, hit.point);
                    lr.positionCount++;

                    position = hit.point;
                    direction = hit.normal;
                    lr.positionCount = i + 2;
                    if (kill == true)
                    {
                        Instantiate(deathEffect, hit.point, Quaternion.identity);
                        hit.collider.GetComponent<Player_Controller>().Die();
                    }
                    
                    break;

                }
                else if (hit.collider.CompareTag("Enemy"))
                {

                    lr.SetPosition(i + 1, hit.point);
                    lr.positionCount++;

                    position = hit.point;
                    direction = hit.normal;
                    lr.positionCount = i + 2;
                    if (kill == true)
                    {
                        Instantiate(deathEffect, hit.point, Quaternion.identity);
                        hit.collider.GetComponent<Player_Controller>().Die();
                    }
                    
                    break;

                }
                else
                {
                    lr.SetPosition(i + 1, hit.point);
                    lr.positionCount++;

                    position = hit.point;
                    direction = hit.normal;
                }


                
            }
            else
            {
  
                lr.SetPosition(i+1, direction * 1000);
                lr.positionCount = i + 2;
                break;
            }

            
        }
    }

}
