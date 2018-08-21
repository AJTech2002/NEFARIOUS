using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LedgeSystem;

namespace Backup
{
    public class LedgeMotorBackup : MonoBehaviour
    {

        public bool drawGizmos;

        [Header("Movement Variables")]
        public float trickleSpeed = 0.2f;
        public float clampSpeed;
        public float moveSpeed;
        public float jumpSpeed;



        [Header("Attributes")]
        public float safetyConnectionDistance = 0.6f;

        public Motor motor;
        public LedgeController ledgeController;
        private Vector3 lastPoint;
        public int precision;
        RaycastHit lastHit;

        CObject currentLedge;

        LedgePoint closestPoint;
        LedgePoint closestPoint2;
        List<Vector3> attachPoints = new List<Vector3>();


        LedgePoint tempLastP;
        LedgePoint tempLastP2;

        int closestIndex = 0;

        Vector3 relativeForwardOfLedge = new Vector3();

        public bool motorHasControl = true;

        public bool isAttached;
        Vector3 attachPoint;



        // 2 PROBLEMS : 

        // LOOPS ARE LEDGE INDIVIDUALISED 
        // LEDGES CANNOT GET MIXED BETWEEN EACHOTHER IN COBJECTS 



        private Vector3 bestCenter;
        private void LateUpdate()
        {
            if (motorHasControl == true)
            {
                //Connection logic


                if (motor.cPS == Motor.PlayerState.Jumping)
                {
                    Vector3 s = (motor.topPoint()) + motor.cVelocity.normalized;
                    Ray ray = new Ray(s, Vector3.down);

                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 2, motor.discludePlayerMask))
                    {
                        if (hit.point.y > transform.position.y - motor.playerHeight / 2)
                        {
                            Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.green, 2);

                            bool lastPointDetected = false;
                            for (int i = 0; i < precision; i++)
                            {
                                Vector3 dir = transform.position - hit.point;
                                dir /= precision;
                                Vector3 p = hit.point + (dir * i);

                                Ray ray2 = new Ray(p + Vector3.up * 0.2f, Vector3.down);
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

                                            if (hit2.transform.GetComponent<CObject>() != null)
                                                currentLedge = hit2.transform.GetComponent<CObject>();


                                            ///

                                            DetectLedgePoint(lastPoint);

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

                if (currentLedge != null && currentLedge.ledges.Count > 0)
                {

                    List<LedgeInformation> closestPointList = new List<LedgeInformation>();

                    for (int l = 0; l < currentLedge.ledges.Count; l++)
                    {
                        List<LedgePoint> pts = currentLedge.returnRealPointsFrom(l);

                        LedgePoint tempPoint = pts[0];
                        int tempIndex = 0;

                        for (int i = 0; i < pts.Count; i++)
                        {
                            if (Vector3.Distance(pts[i].AbsolutePoint, transform.position) < Vector3.Distance(tempPoint.AbsolutePoint, transform.position))
                            {
                                tempPoint = pts[i];
                                tempIndex = i;
                            }
                        }

                        closestPointList.Add(new LedgeInformation(tempPoint, l, tempIndex));

                    }


                    LedgeInformation selectedInfo = closestPointList[0];
                    for (int i = 0; i < closestPointList.Count; i++)
                    {
                        if (Vector3.Distance(closestPointList[i].p.AbsolutePoint, transform.position) < Vector3.Distance(selectedInfo.p.AbsolutePoint, transform.position))
                        {
                            selectedInfo = closestPointList[i];
                        }

                    }

                    closestPoint = selectedInfo.p;


                    List<LedgePoint> prts = currentLedge.returnRealPointsFrom(selectedInfo.ledgeIndex);


                    Vector3 normalisedDirection = (transform.position - closestPoint.AbsolutePoint).normalized;

                    int afterIndex = selectedInfo.localIndex + 1;
                    int beforeIndex = selectedInfo.localIndex - 1;



                    if (beforeIndex >= 0)
                    {

                    }
                    else
                    {
                        if (currentLedge.ledges[selectedInfo.ledgeIndex].isLoopedConnection)
                            beforeIndex = prts.Count - 1;
                        else
                            beforeIndex = -99;
                    }

                    if (afterIndex <= prts.Count - 1)
                    {

                    }
                    else
                    {
                        if (currentLedge.ledges[selectedInfo.ledgeIndex].isLoopedConnection)
                            afterIndex = 0;
                        else
                            afterIndex = -99;
                    }


                    if (afterIndex != -99 && beforeIndex != -99)
                    {
                        Vector3 dB = (prts[beforeIndex].AbsolutePoint - closestPoint.AbsolutePoint).normalized;
                        Vector3 dA = (prts[afterIndex].AbsolutePoint - closestPoint.AbsolutePoint).normalized;


                        if (Vector3.Distance(dB, normalisedDirection) < Vector3.Distance(dA, normalisedDirection))
                        {
                            //DB
                            closestPoint2 = prts[beforeIndex];
                        }
                        else
                        {
                            //DA
                            closestPoint2 = prts[afterIndex];
                        }

                    }
                    else if (afterIndex != -99 && beforeIndex == -99)
                    {
                        closestPoint2 = prts[afterIndex];
                    }
                    else if (afterIndex == -99 && beforeIndex != -99)
                    {
                        closestPoint2 = prts[beforeIndex];
                    }



                }

                if (closestPoint != null && closestPoint2 != null)
                {
                    if (closestPoint != tempLastP || closestPoint2 != tempLastP2)
                    {
                        ForwardDir();
                    }


                }
            }
            else
            {
                //Movement logic && Dismount logic

                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Vector3 r = Camera.main.transform.right;

                //Vector3 r = (closestPoint.AbsolutePoint - closestPoint2.AbsolutePoint);

                // if (CloserTo(r,closestPoint.AbsolutePoint,closestPoint2.AbsolutePoint))
                //{
                //    r *= -1;
                //}

                r *= x * trickleSpeed;

                ReUpdate(transform.position + r, r);

                //Debug.DrawRay(refPoint, relativeForwardOfLedge * 10, Color.red, 10);


                Debug.DrawLine(pointToBe, refPoint, Color.red, 0.5f);
                if (pointToBe != lastPointToBe)
                {
                    lastPointToBe = pointToBe;
                    ConnectToPoint(refPoint, relativeForwardOfLedge, moveSpeed, pointToBe);
                }

                if (Input.GetKeyDown(KeyCode.Space) && closestPoint.connections.Count > 0)
                {
                    //print("MAKES IT IN");

                    Vector3 relativeDir = Camera.main.transform.TransformDirection(new Vector3(x, y, 0) * jumpSpeed);
                    relativeDir += transform.position;
                    Debug.DrawLine(transform.position, relativeDir, Color.blue, 0.5f);
                    //relativeDir.Normalize();

                    LedgeConnection[] connections = closestPoint.connections.ToArray();
                    //connections.AddRange(closestPoint2.connections);

                    //FIND BEST CONNECTION AND HIGHLIGHT

                    LedgeConnection temp = connections[0];
                    Vector3 tempCenter = Vector3.one * 100; ;
                    for (int i = 0; i < connections.Length; i++)
                    {

                        LedgePair pair = connections[i].whichOppositePair(closestPoint, closestPoint2);
                        if (pair != null)
                        {
                            // print("FOUND"); 
                            /// print("FOUND MATCHING PAIR");
                            Vector3 center = (pair.a.AbsolutePoint + pair.b.AbsolutePoint) / 2;

                            Vector3 dir = (center - transform.position);

                            if (Vector3.Distance(relativeDir, tempCenter) > Vector3.Distance(relativeDir, center))
                            {
                                //  print("FOUND ANY");
                                temp = connections[i];
                                tempCenter = center;
                            }
                        }


                    }

                    LedgePair p = temp.whichOppositePair(closestPoint, closestPoint2);
                    if (p != null)
                    {
                        Debug.DrawLine(transform.position, p.a.AbsolutePoint, Color.red, 10);
                        Debug.DrawLine(transform.position, p.b.AbsolutePoint, Color.red, 10);

                        currentLedge = p.a.parentLedge;
                        Vector3 center = p.a.AbsolutePoint + p.b.AbsolutePoint;
                        center /= 2;
                        ReUpdate(center, transform.right);

                    }


                }


            }
        }


        private void ReUpdate(Vector3 pos, Vector3 r2)
        {
            if (currentLedge != null && currentLedge.ledges.Count > 0)
            {
                List<LedgeInformation> closestPointList = new List<LedgeInformation>();

                for (int l = 0; l < currentLedge.ledges.Count; l++)
                {
                    List<LedgePoint> pts = currentLedge.returnRealPointsFrom(l);

                    LedgePoint tempPoint = pts[0];
                    int tempIndex = 0;

                    for (int i = 0; i < pts.Count; i++)
                    {
                        if (Vector3.Distance(pts[i].AbsolutePoint, pos) < Vector3.Distance(tempPoint.AbsolutePoint, pos))
                        {
                            tempPoint = pts[i];
                            tempIndex = i;
                        }
                    }

                    closestPointList.Add(new LedgeInformation(tempPoint, l, tempIndex));

                }


                LedgeInformation selectedInfo = closestPointList[0];
                for (int i = 0; i < closestPointList.Count; i++)
                {
                    if (Vector3.Distance(closestPointList[i].p.AbsolutePoint, pos) <= Vector3.Distance(selectedInfo.p.AbsolutePoint, pos))
                    {
                        selectedInfo = closestPointList[i];
                    }

                }

                closestPoint = selectedInfo.p;


                List<LedgePoint> prts = currentLedge.returnRealPointsFrom(selectedInfo.ledgeIndex);


                Vector3 normalisedDirection = (pos - closestPoint.AbsolutePoint).normalized;

                int afterIndex = selectedInfo.localIndex + 1;
                int beforeIndex = selectedInfo.localIndex - 1;



                if (beforeIndex >= 0)
                {

                }
                else
                {
                    if (currentLedge.ledges[selectedInfo.ledgeIndex].isLoopedConnection)
                        beforeIndex = prts.Count - 1;
                    else
                        beforeIndex = -99;
                }

                if (afterIndex <= prts.Count - 1)
                {

                }
                else
                {
                    if (currentLedge.ledges[selectedInfo.ledgeIndex].isLoopedConnection)
                        afterIndex = 0;
                    else
                        afterIndex = -99;
                }


                if (afterIndex != -99 && beforeIndex != -99)
                {
                    Vector3 dB = (prts[beforeIndex].AbsolutePoint - closestPoint.AbsolutePoint).normalized;
                    Vector3 dA = (prts[afterIndex].AbsolutePoint - closestPoint.AbsolutePoint).normalized;


                    if (Vector3.Distance(dB, normalisedDirection) < Vector3.Distance(dA, normalisedDirection))
                    {
                        //DB
                        closestPoint2 = prts[beforeIndex];
                    }
                    else
                    {
                        //DA
                        closestPoint2 = prts[afterIndex];
                    }

                }
                else if (afterIndex != -99 && beforeIndex == -99)
                {
                    closestPoint2 = prts[afterIndex];
                }
                else if (afterIndex == -99 && beforeIndex != -99)
                {
                    closestPoint2 = prts[beforeIndex];
                }
            }
            if (closestPoint != null && closestPoint2 != null)
            {
                if (closestPoint != tempLastP || closestPoint2 != tempLastP2)
                {



                }

                ForwardDir();
            }

            if (attachPoints.Count > 0)
            {
                Vector3 tempPoint = attachPoints[0];
                for (int i = 0; i < attachPoints.Count; i++)
                {
                    if (Vector3.Distance(pos, tempPoint) > Vector3.Distance(pos, attachPoints[i]))
                    {
                        tempPoint = attachPoints[i];
                        refPoint = tempPoint;
                        pointToBe = refPoint - relativeForwardOfLedge;
                    }
                }

            }

        }


        public Vector3 retrieveForward()
        {
            /// GET THE NORMALISED POSITION
            Vector3 r = (closestPoint.AbsolutePoint - closestPoint2.AbsolutePoint).normalized;
            Vector3 r1 = (closestPoint2.AbsolutePoint - closestPoint.AbsolutePoint).normalized;


            Vector3 f = Vector3.Cross(r, Vector3.up);
            Vector3 f1 = Vector3.Cross(r1, Vector3.up);

            r = transform.TransformDirection(r);
            r1 = transform.TransformDirection(r1);

            Vector3 g = Vector3.zero;

            Vector3 dir = (transform.position - ((closestPoint.AbsolutePoint + closestPoint2.AbsolutePoint) / 2));
            Vector3 center = (closestPoint.AbsolutePoint + closestPoint2.AbsolutePoint) / 2;

            Ray fRay = new Ray((center + f * 0.2f) + Vector3.up, Vector3.down);
            Ray f1Ray = new Ray((center + f1 * 0.2f) + Vector3.up, Vector3.down);
            RaycastHit f1Hit = new RaycastHit();
            RaycastHit fHit = new RaycastHit();




            if (Physics.Raycast(fRay, out fHit, Mathf.Infinity, motor.discludePlayerMask))
            {
                if (fHit.transform == currentLedge.transform)
                {
                    //if (fHit.distance <= 0.5f)
                    // {
                    g = f1;
                    Debug.DrawLine(center, fRay.origin, Color.red, 10);
                    Debug.DrawRay(fRay.origin, fRay.direction, Color.red, 10);
                    //}
                }
            }
            else
            {
                if (Physics.Raycast(f1Ray, out f1Hit, Mathf.Infinity, motor.discludePlayerMask))
                {
                    if (f1Hit.transform == currentLedge.transform)
                    {
                        //   if (f1Hit.distance <= 0.5f)
                        //   {
                        g = f;
                        Debug.DrawLine(center, f1Ray.origin, Color.red, 10);
                        Debug.DrawRay(f1Ray.origin, f1Ray.direction, Color.red, 10);
                        //   }
                    }
                }
            }

            return g;

        }

        LedgePoint cP;
        LedgePoint cP2;

        Vector3 pointToBe;

        private void ForwardDir()
        {
            //GENERATION IS DONE HERE
            attachPoints = currentLedge.selectionDivision(closestPoint, closestPoint2);
            attachPoints.Add(closestPoint.AbsolutePoint);
            attachPoints.Add(closestPoint2.AbsolutePoint);

            tempLastP = closestPoint;
            tempLastP2 = closestPoint2;


            /// GET THE NORMALISED POSITION
            Vector3 r = (closestPoint.AbsolutePoint - closestPoint2.AbsolutePoint).normalized;
            Vector3 r1 = (closestPoint2.AbsolutePoint - closestPoint.AbsolutePoint).normalized;


            Vector3 f = Vector3.Cross(r, Vector3.up);
            Vector3 f1 = Vector3.Cross(r1, Vector3.up);

            r = transform.TransformDirection(r);
            r1 = transform.TransformDirection(r1);

            Vector3 g = Vector3.zero;

            Vector3 dir = (transform.position - ((closestPoint.AbsolutePoint + closestPoint2.AbsolutePoint) / 2));
            //Vector3 dir = Vector3.Cross(transform.forward, transform.up);
            /* if (Vector3.Distance(f, dir) < Vector3.Distance(f1, dir))
             {
                 g = f;
             }
             else
                 g = f1;
                 */

            // if (Vector3.Distance(f, dir) < Vector3.Distance(f1, dir))
            //{
            //  g = f;
            //}
            //else
            //  g = f1;

            Vector3 center = (closestPoint.AbsolutePoint + closestPoint2.AbsolutePoint) / 2;

            Ray fRay = new Ray((center + f * 0.2f) + Vector3.up, Vector3.down);
            Ray f1Ray = new Ray((center + f1 * 0.2f) + Vector3.up, Vector3.down);
            RaycastHit f1Hit = new RaycastHit();
            RaycastHit fHit = new RaycastHit();




            if (Physics.Raycast(fRay, out fHit, Mathf.Infinity, motor.discludePlayerMask))
            {
                if (fHit.transform == currentLedge.transform)
                {
                    //if (fHit.distance <= 0.5f)
                    // {
                    g = (fHit.point - center).normalized;
                    g.y *= 0;
                    Debug.DrawRay(center, g, Color.magenta, 5);
                    Debug.DrawLine(center, fRay.origin, Color.red, 10);
                    Debug.DrawRay(fRay.origin, fRay.direction, Color.red, 10);
                    //}
                }
                else
                {
                    Debug.DrawLine(center, fRay.origin, Color.yellow, 10);
                    Debug.DrawRay(fRay.origin, fRay.direction, Color.yellow, 10);
                }
            }
            else
            {
                Debug.DrawLine(center, fRay.origin, Color.yellow, 10);
                Debug.DrawRay(fRay.origin, fRay.direction, Color.yellow, 10);
            }

            if (Physics.Raycast(f1Ray, out f1Hit, Mathf.Infinity, motor.discludePlayerMask))
            {
                if (f1Hit.transform == currentLedge.transform)
                {
                    //   if (f1Hit.distance <= 0.5f)
                    //   {
                    g = (f1Hit.point - center).normalized;
                    g.y *= 0;
                    Debug.DrawRay(center, g, Color.magenta, 5);
                    Debug.DrawLine(center, f1Ray.origin, Color.red, 10);
                    Debug.DrawRay(f1Ray.origin, f1Ray.direction, Color.red, 10);
                    //   }
                }
                else
                {
                    Debug.DrawLine(center, f1Ray.origin, Color.yellow, 10);
                    Debug.DrawRay(f1Ray.origin, f1Ray.direction, Color.yellow, 10);
                }
            }
            else
            {
                Debug.DrawLine(center, f1Ray.origin, Color.yellow, 10);
                Debug.DrawRay(f1Ray.origin, f1Ray.direction, Color.yellow, 10);
            }
            relativeForwardOfLedge = g;



        }

        public bool CloserTo(Vector3 a, Vector3 toB, Vector3 thanC)
        {

            if (Vector3.Distance(a, toB) < Vector3.Distance(a, thanC))
            {
                return true;
            }

            return false;

        }

        public Vector3 refPoint = Vector3.zero;
        Vector3 lastPointToBe;
        private void DetectLedgePoint(Vector3 hitPoint)
        {
            if (attachPoints.Count > 0)
            {
                Vector3 tempPoint = attachPoints[0];
                for (int i = 0; i < attachPoints.Count; i++)
                {
                    if (Vector3.Distance(hitPoint, tempPoint) > Vector3.Distance(hitPoint, attachPoints[i]))
                    {
                        tempPoint = attachPoints[i];
                        refPoint = tempPoint;
                        pointToBe = refPoint - relativeForwardOfLedge;
                        /// CONNECT TO POINT ///



                    }
                }
                if (Vector3.Distance(motor.topPoint(), tempPoint) <= safetyConnectionDistance)
                {
                    //Debug.DrawRay(tempPoint, relativeForwardOfLedge * 10, Color.red, 10);

                    ledgeController.Attach();

                    if (pointToBe != lastPointToBe)
                    {
                        lastPointToBe = pointToBe;
                        ConnectToPoint(tempPoint, relativeForwardOfLedge, clampSpeed, pointToBe);
                        motorHasControl = false;
                    }
                }
            }
        }

        private void ConnectToPoint(Vector3 attachPoint, Vector3 relForw, float sp, Vector3 point)
        {
            if (ledgeController.hasControl)
            {
                // ! IMPORTANT ! : CHANGED TO NULL HERE 
                Debug.LogError("NULL HERE YOU SET THIS, COME AND FIX IT TO 'THIS' ");
                //ledgeController.ResetPosition(attachPoint, relForw, sp, null, point, false, LedgeConnection.ConnectionType.Normal);

                isAttached = true;
            }
            else
            {
                motorHasControl = true;
                isAttached = false;
            }
        }



        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(lastPoint, 0.1f);


                if (closestPoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawCube(closestPoint.AbsolutePoint, Vector3.one / 3);

                    if (closestPoint2 != null)
                        Gizmos.DrawCube(closestPoint2.AbsolutePoint, Vector3.one / 3);

                }

                if (attachPoints != null && attachPoints.Count > 0)
                {
                    for (int i = 0; i < attachPoints.Count; i++)
                    {
                        Gizmos.color = Color.cyan;
                        Gizmos.DrawCube(attachPoints[i], Vector3.one / 3);
                    }
                }

                Gizmos.color = Color.red;
                Gizmos.DrawCube(refPoint, Vector3.one / 2.5f);
            }
        }

    }


    [System.Serializable]
    public class LedgeInformation
    {
        public LedgePoint p;
        public int ledgeIndex = 0;
        public int localIndex = 0;

        public LedgeInformation(LedgePoint point, int ledgeI, int locI)
        {
            p = point;
            ledgeIndex = ledgeI;
            localIndex = locI;
        }

    }

}
/*
 if (currentLedge != null && currentLedge.ledges.Count > 0)
   {
       List<LedgePoint> pts = currentLedge.retAllPoints();

       LedgePoint tempPoint = pts[0];
       int tempIndex = 0;

       for (int i = 0; i < pts.Count; i++)
       {
           if (Vector3.Distance(pts[i].AbsolutePoint,transform.position) < Vector3.Distance(tempPoint.AbsolutePoint, transform.position))
           {
               tempPoint = pts[i];
               tempIndex = i;
           }
       }


       closestPoint = tempPoint;

       Vector3 normalisedDirection = (transform.position - closestPoint.AbsolutePoint).normalized;

       int afterIndex = tempIndex + 1;
       int beforeIndex = tempIndex - 1;



       if (beforeIndex >= 0)
       {

       }
       else
       {
           if (currentLedge.isLoopedConnection)
               beforeIndex = pts.Count - 1;
           else
               beforeIndex = -99;
       }

       if (afterIndex <= pts.Count-1)
       {

       }
       else
       {
           if (currentLedge.isLoopedConnection)
               afterIndex = 0;
           else
               afterIndex = -99;
       }


       if (afterIndex != -99 && beforeIndex != -99)
       {
           Vector3 dB = (pts[beforeIndex].AbsolutePoint - closestPoint.AbsolutePoint).normalized;
           Vector3 dA = (pts[afterIndex].AbsolutePoint - closestPoint.AbsolutePoint).normalized;


           if (Vector3.Distance(dB, normalisedDirection) < Vector3.Distance(dA, normalisedDirection))
           {
               //DB
               closestPoint2 = pts[beforeIndex];
           }
           else
           {
               //DA
               closestPoint2 = pts[afterIndex];
           }

       }
       else if (afterIndex != -99 && beforeIndex == -99)
       {
           closestPoint2 = pts[afterIndex];
       }
       else if (afterIndex == -99 && beforeIndex != -99)
       {
           closestPoint2 = pts[beforeIndex];
       }



   }
   */
