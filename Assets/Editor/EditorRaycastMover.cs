using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RaycastMove))]
public class EditorRaycastMover : Editor
{
    public override void OnInspectorGUI()
    {
        RaycastMove t = (RaycastMove)target;
        DrawDefaultInspector();
        
        GUIStyle style = new GUIStyle();
        style.fontSize = 18;
        style.normal.background = Texture2D.grayTexture;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.MiddleCenter;
     


        GUILayout.Space(25);


        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Create Grid",style))
        {
            t.CreateGrid();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Delete Grid",style))
        {
            if (EditorUtility.DisplayDialog("Delete Grid", "Are you sure you want to delete exisiting grid", "Yes",
                "No"))
            {
                if (t.p.gameObject)
                {
                    DestroyImmediate(t.p.gameObject);
                }
          
            }
        }
        GUILayout.EndHorizontal();
        
    }
}
