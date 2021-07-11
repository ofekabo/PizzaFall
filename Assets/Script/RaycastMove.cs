using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RaycastMove : MonoBehaviour
{
  
    [SerializeField] LayerMask ignoreLayers = new LayerMask();
    
    private Mover _pizzaMover;
    // debugging
    [SerializeField] bool showDebug;
    [SerializeField] Vector2 vecStart;
    [SerializeField] float xSpace,zSpace;
    [SerializeField] int columnLength,rowLength;
    
    private Camera _cam;
    private static Transform _pizza;
    
    [InitializeOnLoadMethod]
    static void FindPizza()
    {
        _pizza = GameObject.Find("Pizza").transform;
        Debug.Log(_pizza.gameObject);
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
        
            _pizza.position = new Vector3(
                FindClosestTarget(hit.point,"GridObject").transform.position.x,
                _pizza.position.y,
                FindClosestTarget(hit.point,"GridObject").transform.position.z);
        
      
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
        
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Gizmos.DrawCube(new Vector3(vecStart.x + xSpace * (i %columnLength),0,vecStart .y + zSpace * (i / columnLength)),Vector3.one);
        }
    }

    [ContextMenu("Create Grid")]
    private void CreateGrid()
    {
        GameObject parent = new GameObject("GridParent");
        int j = 1;
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            GameObject gridPos = new GameObject();
            gridPos.name = $"Grid Position : {j}";
            gridPos.transform.position = new Vector3(vecStart.x + xSpace * (i %columnLength),0,vecStart .y + zSpace * (i / columnLength));
            gridPos.tag = "GridObject";
            gridPos.transform.parent = parent.transform;
            j++;
        }
    }
}
