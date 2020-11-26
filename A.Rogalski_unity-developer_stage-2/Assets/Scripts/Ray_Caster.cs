using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Caster : MonoBehaviour
{
    public int RayCount = 10;
    private LineRenderer lr;
    private bool holding = false;
    private Color c1 = new Color(1, 1, 1, 1);
    private Color c2 = new Color(1, 1, 1, 0);

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        holding = false;

    }

    void Update()
    {
        if (holding == true)
        {
            Aiming(transform.position, transform.forward, false);
        }
        if(Input.GetMouseButtonDown(0))
        {
            holding = true;
            lr.SetColors(c1, c1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            holding = false;
            lr.SetColors(c2, c2);
            Aiming(transform.position, transform.forward, true);


        }
        print(holding);

    }

    void Aiming(Vector3 position, Vector3 direction, bool kill)
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
                        hit.collider.GetComponent<Enemy_Controller>().Die();
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
