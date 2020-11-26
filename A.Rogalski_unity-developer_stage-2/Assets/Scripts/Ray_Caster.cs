using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Caster : MonoBehaviour
{
    public int RayCount = 10;
    private LineRenderer lr;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem deathEffect;
    private bool holding = false;
    private Color c1 = new Color(1, 1, 1, 1);
    private Color c2 = new Color(1, 1, 1, 0);

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        holding = false;
        anim.SetBool("Aiming", true);

    }

    void Update()
    {
        
        Aiming(transform.position, transform.forward, false);
        
        /*if (Input.GetMouseButtonUp(0))
        {
            holding = false;
            lr.SetColors(c2, c2);
            Aiming(transform.position, transform.forward, true);
            anim.SetTrigger("Attack");
            anim.SetBool("Aiming", false);



        }*/
    

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
