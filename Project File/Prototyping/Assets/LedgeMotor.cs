using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeMotor : MonoBehaviour {

    public Motor motor;
    public LedgeController ledgeController;
    private Vector3 lastPoint;
    public int precision;
    RaycastHit lastHit;
   

    private void LateUpdate()
    {
        if (motor.cPS == Motor.PlayerState.Jumping)
        {
           Vector3 s = (motor.topPoint()) + motor.cVelocity.normalized;
            Ray ray = new Ray(s, Vector3.down);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2, motor.discludePlayerMask))
            {
                if (hit.point.y > transform.position.y-motor.playerHeight/2)
                {
                    Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.green, 2);

                    bool lastPointDetected = false;
                    for (int i = 0; i < precision; i++)
                    {
                        Vector3 dir = transform.position - hit.point;
                        dir /= precision;
                        Vector3 p = hit.point + (dir*i);

                        Ray ray2 = new Ray(p+Vector3.up*0.2f, Vector3.down);
                        RaycastHit hit2;

                        if (Physics.Raycast(ray2, out hit2, 2, motor.discludePlayerMask))
                        {
                            if (hit2.transform == hit.transform && hit2.normal == hit.normal)
                            {
                                if (hit2.point.y > (transform.position.y - motor.playerHeight / 2) + motor.liftCutoff)
                                {
                                    lastPointDetected = true;
                                    lastPoint = hit2.point;
                                    lastHit = hit2;
                                   
                                }
                               
                            }
                            else
                            {
                                break;
                            }
                        }

                    }

                    if (lastPointDetected)
                    {


                    }

                    

                }

            }

           
        }
    


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(lastPoint, 0.1f);
    }

}
