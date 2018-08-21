using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LedgeSystem;

public class LedgeEditor : EditorWindow
{
    Transform[] selection;
    LedgeConnection.ConnectionType connectionType;
    CObject selectedCO;

    /* Control Options */
    public bool locked;
    public bool isHoverSelect = true;
    public bool editorEnabled = false;

    public bool buildingConnections = false;

    public bool ledgeIsLooped = false;

    Vector2 scroll = Vector2.zero;

    private void OnGUI()
    {
        
        GUILayout.Label("Ledge Editor v1");
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        
        if (GUILayout.Button("ENABLE/DISABLE"))
        {
            editorEnabled = !editorEnabled;
        }
        GUILayout.Space(30);

        if (GUILayout.Button("Remove Doubles"))
        {

            if (Selection.activeTransform.GetComponent<CObject>() != null)
            {
                CObject obj = Selection.activeTransform.GetComponent<CObject>();

                for (int i = 0; i < obj.ledges.Count; i++)
                {
                    List<int> doubleV = new List<int>();
                    for (int p = 0; p < obj.ledges[i].points.Count; p++)
                    {
                        if (doubleV.Contains(obj.ledges[i].points[p].index))
                        {
                            obj.ledges[i].points.RemoveAt(p);
                            Debug.Log("Removed 1 double");
                            continue;
                        }

                        doubleV.Add(obj.ledges[i].points[p].index);

                    }

                   

                }

            }
        }

        if (GUILayout.Button("Clear Ledges"))
        {

            if (Selection.activeTransform.GetComponent<CObject>() != null)
            {
                CObject obj = Selection.activeTransform.GetComponent<CObject>();
                obj.ledges.Clear();
            }

        }

        if (GUILayout.Button("Clear Connections"))
        {
            //MY NAME IS AJAY
            if (Selection.activeTransform.GetComponent<CObject>() != null)
            {
                CObject obj = Selection.activeTransform.GetComponent<CObject>();

                for (int i = 0; i < obj.ledges.Count; i++)
                {
                    for (int p = 0; p < obj.ledges[i].points.Count; p++)
                    {

                        obj.ledges[i].points[p].connections.Clear();
                    }
                }

            }

        }

        GUILayout.Space(30);

        if (editorEnabled)
        {
            ledgeIsLooped = GUILayout.Toggle(ledgeIsLooped, "Is the ledge looped ? : ");
            buildingConnections = GUILayout.Toggle(buildingConnections, "Creating connections ? : ");
            
            if (GUILayout.Button("Create Ledge") && selectedTransform != null && !buildingConnections || Event.current.keyCode == KeyCode.Return)
            {
                if (selectedTransform.GetComponent<CObject>() == null)
                {
                    selectedTransform.gameObject.AddComponent<CObject>();
                    selectedTransform.gameObject.GetComponent<CObject>().m = tempMesh;
                }

                List<LedgePoint> points = new List<LedgePoint>();
                for (int i = 0; i < selectionBuffer.Count; i++)
                {
                    LedgePoint p = new LedgePoint(selectedTransform.gameObject.GetComponent<CObject>(), selectionBuffer[i],LedgePoint.PointType.Normal, selectedTransform.GetComponent<CObject>().ledges.Count, i);
                    points.Add(p);
                }

                Debug.Log(points.Count);

                Ledge l = new Ledge(Ledge.LedgeType.Normal, points, ledgeIsLooped);

                selectedTransform.GetComponent<CObject>().ledges.Add(l);

                selectionBuffer.Clear();
                drawBuffer.Clear();

                connectionBuffer.Clear();

            }


            if (GUILayout.Button("Create Connection") && ledgePair.Count > 0 && buildingConnections || Event.current.keyCode == KeyCode.Return) 
            {

                for (int i = 0; i < ledgePair.Count; i++)
                {
                    for (int x = 0; x < ledgePair.Count; x++)
                    {
                        if (ledgePair[i].a.parentLedgeIndex == ledgePair[x].a.parentLedgeIndex && ledgePair[i].a.parentLedge == ledgePair[x].a.parentLedge)
                        {
                           
                            continue;

                        }

                        

                       // LedgeConnection a = new LedgeConnection(LedgeConnection.ConnectionType.Normal, new LedgePair(ledgePair[i].a, ledgePair[i].b), new LedgePair(ledgePair[x].a, ledgePair[x].b));
                       // LedgeConnection b = new LedgeConnection(LedgeConnection.ConnectionType.Normal, new LedgePair(ledgePair[x].a, ledgePair[x].b), new LedgePair(ledgePair[i].a, ledgePair[i].b));

                        ledgePair[i].a.connections.Add(new LedgeConnection(connectionType, new LedgePair(ledgePair[i].a, ledgePair[i].b), new LedgePair(ledgePair[x].a, ledgePair[x].b)));
                        ledgePair[x].a.connections.Add(new LedgeConnection(connectionType, new LedgePair(ledgePair[x].a, ledgePair[x].b), new LedgePair(ledgePair[i].a, ledgePair[i].b)));

                        ledgePair[i].b.connections.Add(new LedgeConnection(connectionType, new LedgePair(ledgePair[i].a, ledgePair[i].b), new LedgePair(ledgePair[x].a, ledgePair[x].b)));
                        ledgePair[x].b.connections.Add(new LedgeConnection(connectionType, new LedgePair(ledgePair[x].a, ledgePair[x].b), new LedgePair(ledgePair[i].a, ledgePair[i].b)));

                        EditorUtility.SetDirty(ledgePair[i].a.parentLedge);
                        EditorUtility.SetDirty(ledgePair[x].a.parentLedge);

                  

                    }
                }

               
                ledgePair.Clear();
                currentlyFilling = new LedgePair();



            }


            GUILayout.Space(30);

            if (GUILayout.Button("Clear Buffer") || Event.current.alt && Event.current.keyCode == KeyCode.R)
            {
                selectionBuffer.Clear();
                drawBuffer.Clear();
                connectionBuffer.Clear();
                ledgeBuffer.Clear();
                ledgePair.Clear();



            }

            if (GUILayout.Button("Clear Currently Filling"))
            {
                if (currentlyFilling == null)
                    currentlyFilling = new LedgePair();
                else if (currentlyFilling != null)
                    currentlyFilling = new LedgePair();
            }

            GUILayout.Space(30);

            GUILayout.Space(20);
            if (GUILayout.Button("Toggle Hover Select"))
            {
                isHoverSelect = !isHoverSelect;
            }

        }

        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        //PROPERTIES TAB
        GUILayout.EndVertical();

        connectionType = (LedgeConnection.ConnectionType)EditorGUILayout.EnumPopup("Connection Type : ", connectionType);

        GUILayout.EndHorizontal();
  
        if (Selection.transforms != null)
        {
            selection = Selection.transforms;

            ///if (Selection.activeTransform.GetComponent<CObject>() != null)
            //    selectedCO = Selection.activeTransform.GetComponent<CObject>();

           // selectedTransform = Selection.activeTransform;

        }

        Repaint();
        Handles.color = Color.yellow;

       

    }


    // Window has been selected
    void OnFocus()
    {
        // Remove delegate listener if it has previously
        // been assigned.
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
        // Add (or re-add) the delegate.
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;
    }

    void OnDestroy()
    {
        // When the window is destroyed, remove the delegate
        // so that it will no longer do any drawing.
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
    }

    List<int> selectionBuffer = new List<int>();
    List<Vector3> drawBuffer = new List<Vector3>();
    List<LedgePoint> ledgeBuffer = new List<LedgePoint>();
    List<LedgeConnectRef> connectionBuffer = new List<LedgeConnectRef>();
    List<LedgePair> ledgePair = new List<LedgePair>();
    Mesh tempMesh;
    Transform selectedTransform;
    Face _selectedFace;

    // EACH LEDGE 
    LedgePair currentlyFilling;
    

    // GUI BUTTONS SHOW UP ON WHERE LEDGE POINTS HAVE BEEN ATTACHED --- NEW BUTTONS ---
    // YOU SELECT PAIRS OF LEDGE POINTS W/ SAME PARENT INDEX & COBJ
    // PAIRS ARE COMPARED AND IF THEY DONT HAVE SAME PAR INDEX & COBJ
    // PAIRS ARE MATCHED UP !!!

    void OnSceneGUI(SceneView sceneView)
    {
        
        if (editorEnabled)
        {
            Handles.BeginGUI();

            if (!buildingConnections)
            {


                for (int r = 0; r < selection.Length; r++)
                {
                    MeshFilter go = selection[r].GetComponent<MeshFilter>();

                    //This part of the code runs when control is false and is in charge of the actual handling of mouse to gui selection of faces
                    if (Event.current.control == false)
                    {
                        if (selection[r] != null && selection[r].GetComponent<MeshFilter>() != null && isHoverSelect)
                        {
                            Ray r2 = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                            RaycastHit hit;

                            if (Physics.Raycast(r2, out hit))
                            {
                                if (hit.transform == selection[r])
                                {
                                    MeshCollider meshCollider = hit.collider as MeshCollider;
                                    if (meshCollider == null || meshCollider.sharedMesh == null)
                                        return;


                                    Mesh mesh = meshCollider.sharedMesh;

                                    Vector3[] vertices = mesh.vertices;
                                    int[] triangles = mesh.triangles;
                                    Vector3 p0 = hit.transform.TransformPoint(vertices[triangles[hit.triangleIndex * 3 + 0]]);
                                    Vector3 p1 = hit.transform.TransformPoint(vertices[triangles[hit.triangleIndex * 3 + 1]]);
                                    Vector3 p2 = hit.transform.TransformPoint(vertices[triangles[hit.triangleIndex * 3 + 2]]);
                                    _selectedFace = new Face(p0, p1, p2, hit.transform, triangles[hit.triangleIndex * 3 + 0], triangles[hit.triangleIndex * 3 + 1], triangles[hit.triangleIndex * 3 + 2], mesh);


                                }

                            }
                        }

                        //This part of the code deals with cubes and primitives and allowing their verticies to be selected
                        if (go != null && go.sharedMesh.vertexCount < 250 && !isHoverSelect)
                        {
                            List<Vector3> p = new List<Vector3>();
                            Vector3[] v = go.sharedMesh.vertices;

                            Camera c = Camera.main;
                            for (int i = 0; i < v.Length; i++)
                            {
                                if (!p.Contains(go.transform.TransformPoint(v[i])))
                                {
                                    p.Add(go.transform.TransformPoint(v[i]));
                                    Vector3 a = HandleUtility.WorldToGUIPoint(go.transform.TransformPoint(v[i]));
                                    if (GUI.Button(new Rect(new Vector2(a.x, a.y), new Vector2(40, 20)), i.ToString()))
                                    {
                                        selectionBuffer.Add(i);
                                        selectedTransform = go.transform;
                                        drawBuffer.Add(go.transform.TransformPoint(v[i]));
                                        tempMesh = go.sharedMesh;



                                    }
                                }
                            }
                        }


                    }

                    //This part of the code manages when you have hovered over a face - this displays the GUI buttons and allows you to select them
                    if (isHoverSelect && _selectedFace != null)
                    {

                        Handles.color = Color.red;
                        Handles.DrawLine(_selectedFace.RP0, _selectedFace.RP1);
                        Handles.DrawLine(_selectedFace.RP1, _selectedFace.RP2);
                        Handles.DrawLine(_selectedFace.RP2, _selectedFace.RP0);

                        if (GUI.Button(new Rect(new Vector2(_selectedFace.RP0.x, _selectedFace.RP0.y), new Vector2(40, 20)), "0"))
                        {
                            selectionBuffer.Add(_selectedFace.p0index);
                            selectedTransform = _selectedFace.trans;
                            drawBuffer.Add(_selectedFace.p0);

                            tempMesh = _selectedFace.tempMesh;


                            if (buildingConnections)
                            {
                                connectionBuffer.Add(new LedgeConnectRef(_selectedFace.trans, _selectedFace.tempMesh, _selectedFace.p0index));
                            }


                        }
                        if (GUI.Button(new Rect(new Vector2(_selectedFace.RP1.x, _selectedFace.RP1.y), new Vector2(40, 20)), "1"))
                        {
                            selectionBuffer.Add(_selectedFace.p1index);
                            drawBuffer.Add(_selectedFace.p1);
                            selectedTransform = _selectedFace.trans;
                            tempMesh = _selectedFace.tempMesh;

                            if (buildingConnections)
                            {
                                connectionBuffer.Add(new LedgeConnectRef(_selectedFace.trans, _selectedFace.tempMesh, _selectedFace.p1index));
                            }

                        }
                        if (GUI.Button(new Rect(new Vector2(_selectedFace.RP2.x, _selectedFace.RP2.y), new Vector2(40, 20)), "2"))
                        {
                            selectionBuffer.Add(_selectedFace.p2index);
                            selectedTransform = _selectedFace.trans;
                            drawBuffer.Add(_selectedFace.p2);
                            tempMesh = _selectedFace.tempMesh;

                            if (buildingConnections)
                            {
                                connectionBuffer.Add(new LedgeConnectRef(_selectedFace.trans, _selectedFace.tempMesh, _selectedFace.p2index));
                            }

                        }
                    }
                }

                if (selectionBuffer.Count > 1 && !buildingConnections)
                {
                    for (int i = 0; i < selectionBuffer.Count; i++)
                    {
                        if (i == 0)
                            continue;

                        Vector3 a = HandleUtility.WorldToGUIPoint(drawBuffer[i - 1]);
                        Vector3 b = HandleUtility.WorldToGUIPoint(drawBuffer[i]);
                        if (i != selectionBuffer.Count - 1)
                            Handles.color = Color.green;
                        else
                            Handles.color = Color.yellow;
                        Handles.DrawLine(a, b);

                    }



                }


            }
            else
            {
                for (int r = 0; r < selection.Length; r++)
                {
                    // DRAW BUTTONS
                    if (selection[r].GetComponent<CObject>() != null)
                    {

                        CObject o = selection[r].GetComponent<CObject>();

                        List<LedgePoint> points = o.retAllPoints();

                        for (int i = 0; i < points.Count; i++)
                        {

                            Vector2 worldToGUI = HandleUtility.WorldToGUIPoint(points[i].AbsolutePoint);
                            // DRAW GUI
                            if (currentlyFilling != null && currentlyFilling.a != null && currentlyFilling.a == points[i] || currentlyFilling != null && currentlyFilling.b != null && currentlyFilling.b == points[i])
                                GUI.color = Color.green;
                            else if (ledgeBuffer.Contains(points[i]))
                                GUI.color = Color.red;
                            else
                                GUI.color = Color.white;
                            if (GUI.Button(new Rect(worldToGUI, new Vector2(40, 20)), points[i].parentLedgeIndex.ToString()))
                            {

                                if (currentlyFilling.FillUp(points[i]))
                                {
                                    ledgeBuffer.Add(points[i]);
                                }

                                if (currentlyFilling != null && currentlyFilling.b != null)
                                {
                                    ledgePair.Add(currentlyFilling);
                                    Debug.Log("ADDED");
                                    currentlyFilling = new LedgePair();
                                }

                             

                            }
                            GUI.color = Color.white;


                        }


                    }

                }

                if (buildingConnections && selectionBuffer.Count > 1)
                {
                    for (int i = 0; i < selectionBuffer.Count; i++)
                    {
                        for (int r = 0; r < selectionBuffer.Count; r++)
                        {

                            Vector3 a = HandleUtility.WorldToGUIPoint(drawBuffer[i]);
                            Vector3 b = HandleUtility.WorldToGUIPoint(drawBuffer[r]);
                            if (i != selectionBuffer.Count - 1)
                                Handles.color = Color.green;
                            else
                                Handles.color = Color.yellow;
                            Handles.DrawLine(a, b);

                        }

                    }
                }
            }

            Handles.EndGUI();
            SceneView.RepaintAll();
            HandleUtility.Repaint();
            Repaint();
            
        }

    }
    
    [MenuItem("Locomotion/Ledge System")]
    static void Init()
    {
        EditorWindow w = (EditorWindow)EditorWindow.GetWindow(typeof(LedgeEditor));
        w.Show();
    }


}



/*
        GUILayout.Label("Ledge Editor v1");
        MeshFilter go = GameObject.FindObjectOfType<DrawLine>().GetComponent<MeshFilter>();
        Vector3[] v = go.sharedMesh.vertices;
        Camera c = Camera.main;
        for (int i = 0; i < v.Length; i++)
        {
            Vector3 a = HandleUtility.WorldToGUIPoint(go.transform.TransformPoint(v[i]));
            if (GUI.Button(new Rect(new Vector2(a.x, a.y), new Vector2(20, 20)), i.ToString()))
            {
                Debug.Log(i);
            }
        }



 */


/* if (GUILayout.Button("Create Connection") && buildingConnections)
        {

            //CONNECTION BUFFER

            if (connectionBuffer.Count > 0)
            {

                List<LedgePoint> p = new List<LedgePoint>();

                for (int i = 0; i < connectionBuffer.Count; i++)
                {
                    CObject o = connectionBuffer[i].mainTransform.GetComponent<CObject>();
                    if (o != null)
                    {
                        List<LedgePoint> rp = o.retAllPoints();
                        p.AddRange(rp);
                    }
                }

                List<LedgePoint> _CONNECTIONS = new List<LedgePoint>();

                for (int i = 0; i < connectionBuffer.Count; i++)
                {

                    for (int a = 0; a < p.Count; a++)
                    {

                        if (connectionBuffer[i].vertexIndex == p[a].index)
                        {

                            _CONNECTIONS.Add(p[i]);


                        }


                    }

                }

                for (int i = 0; i < _CONNECTIONS.Count; i++)
                {

                   for (int x = 0; x < _CONNECTIONS.Count; x++)
                    {

                        _CONNECTIONS[i].connections.Add(new LedgeConnection(LedgeConnection.ConnectionType.Normal, _CONNECTIONS[i], _CONNECTIONS[x]));
                        _CONNECTIONS[x].connections.Add(new LedgeConnection(LedgeConnection.ConnectionType.Normal, _CONNECTIONS[x], _CONNECTIONS[i]));
                    }

                }



            }



        } */

/*
       for (int r = 0; r < selection.Length; r++)
       {
           List<Vector3> p = new List<Vector3>();

           MeshFilter go = selection[r].GetComponent<MeshFilter>();


           Ray r2 = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
           RaycastHit h;

           if (Physics.Raycast(r2, out h))
           {
               if (Event.current.control == true)
               {
                   Vector3 v = h.point;
                   Vector3 a = HandleUtility.WorldToGUIPoint(v);
                   if (GUI.Button(new Rect(new Vector2(a.x, a.y), new Vector2(40, 20)), "H"))
                   {
                       Debug.Log("H");
                   }
               }
           }





           if (go != null)
           {
               List<EdgeHelpers.Edge> boundary = EdgeHelpers.GetEdges(go.sharedMesh.triangles).FindBoundary();

               List<Vector3> v = new List<Vector3>();

               for (int i = 0; i < boundary.Count; i++)
               {
                   if (!v.Contains(go.sharedMesh.vertices[boundary[i].v1]))
                       v.Add(go.sharedMesh.vertices[boundary[i].v1]);
                   if (!v.Contains(go.sharedMesh.vertices[boundary[i].v2]))
                       v.Add(go.sharedMesh.vertices[boundary[i].v2]);
               }

               Camera c = Camera.main;
               for (int i = 0; i < v.Count; i++)
               {
                   if (!p.Contains(go.transform.TransformPoint(v[i])))
                   {
                       p.Add(go.transform.TransformPoint(v[i]));
                       Vector3 a = HandleUtility.WorldToGUIPoint(go.transform.TransformPoint(v[i]));
                       if (GUI.Button(new Rect(new Vector2(a.x, a.y), new Vector2(40, 20)), i.ToString()))
                       {
                           Debug.Log(i);
                       }
                   }
               }
           }
       }
   */
