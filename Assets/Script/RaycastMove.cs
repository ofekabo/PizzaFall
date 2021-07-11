using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class RaycastMove : MonoBehaviour
{
    
    [SerializeField] LayerMask ignoreLayers = new LayerMask();
    
    private Mover _pizzaMover;
    // debugging
    [Header("Debug")]
    [SerializeField] bool showDebug;
    [Header("Radius Control")]
    [SerializeField] float height;
    [SerializeField] Vector2 vecStart;
    [SerializeField] float radius;
    [SerializeField] int amount;
    [HideInInspector] [SerializeField] List<Transform> _gridPos = new List<Transform>();
    
    private Camera _cam;
    private static Transform _pizza;
    [HideInInspector]public Transform p;
    
    [InitializeOnLoadMethod]
    static void FindPizza()
    {
        _pizza = GameObject.Find("Pizza").transform;
    }
    
    void Start()
    {
        if (!_pizza)
        {
            _pizza = GameObject.Find("Pizza").transform;
        }
        _cam = Camera.main;
        _pizzaMover = _pizza.GetComponent<Mover>();
    }

    void Update()
    {
      
       
        Ray cameraRay = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(cameraRay.origin,cameraRay.direction * 15.0f,Color.red);
        
        if(_pizzaMover.gotHit) { return; }
        if(!Input.GetMouseButtonDown(0)) { return; }

        if (!Physics.Raycast(cameraRay.origin, cameraRay.direction, out hit, ignoreLayers)) { return; }
        
            Vector3 newPos = FindClosestTarget(hit.point,"GridObject").transform.position;
            _pizza.parent.position = new Vector3(newPos.x, _pizza.parent.position.y, newPos.z);
            
            Vector3 center = Vector3.Lerp(_gridPos[0].position,_gridPos[4].position,0.5f);
            
            var lookPos = center - _pizza.parent.position;
            lookPos.y = 0;
          
            var rotation = Quaternion.LookRotation(lookPos);
            _pizza.parent.rotation = rotation;
            _pizza.parent.Rotate(0,90,0);
         
            Debug.DrawLine(_pizza.position,new Vector3(center.x,_pizza.parent.transform.position.y,center.z),Color.blue,1f);
        
      
    }
    
    
    
    GameObject FindClosestTarget(Vector3 point,string target)
    {
        Vector3 pos = point;
        return GameObject.FindGameObjectsWithTag(target)
            .OrderBy(o => (o.transform.position - pos).sqrMagnitude)
            .FirstOrDefault();
    }
    
    private void OnDrawGizmos()
    {
        if(!showDebug) { return; }
       
    
            
            Gizmos.color = Color.red;
    
            for (int i = 0; i < amount; i++)
                {
                    float angle = i * Mathf.PI * 2 / amount;
                    
                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (radius);
                    Vector3 currentPos = new Vector3(vecStart.x, 0 + height, vecStart.y);
                    Vector3 desiredPos = new Vector3(currentPos.x + pos.x, currentPos.y + pos.y, currentPos.z + pos.z);

                    Gizmos.DrawCube(desiredPos, Vector3.one * 0.2f);
                    // Gizmos.DrawCube(new Vector3(vecStart.x + xSpace* (i %columnLength),0 + height,vecStart.y + zSpace* (i / columnLength)),Vector3.one);
                }
                
            Gizmos.color = Color.blue;
        
            Gizmos.DrawCube(Vector3.Lerp(_gridPos[0].position,_gridPos[4].position,0.5f),Vector3.one);
        

 
    }

    [ContextMenu("Create Grid")]
    public void CreateGrid()
    {
        _gridPos.Clear();
        GameObject parent = new GameObject("GridParent");
        p = parent.transform;
        int nameNumb = 1;
        
  
        
        for (int i = 0; i < amount; i++)
        {
            GameObject gridPos = new GameObject();
            
            float angle = i * Mathf.PI * 2 / amount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Vector3 currentPos = new Vector3(vecStart.x, 0 + height, vecStart.y);
            Vector3 desiredPos = new Vector3(currentPos.x + pos.x, currentPos.y + pos.y, currentPos.z + pos.z);
            
            gridPos.name = $"Grid Position : {nameNumb}";
            _gridPos.Add(gridPos.transform);

            gridPos.transform.position = desiredPos;
            gridPos.tag = "GridObject";
            gridPos.transform.parent = parent.transform;
            nameNumb++;
        }
        
        
    }
}
