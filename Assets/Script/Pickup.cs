using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Texture _texture;

    [SerializeField] private ParticleSystem ppSystem;

    [SerializeField] private GameObject x2Object;

    [SerializeField] private Vector3 offset;
    
    
    // [SerializeField] private Material pizzaMaterial;

    private void Start()
    {
     
           
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // pizzaMaterial.SetTexture("_MainTex",_texture);
        other.GetComponent<Renderer>().material.mainTexture = _texture;
        Instantiate(ppSystem, transform.position,quaternion.identity);
        Destroy(gameObject,0.1f);
        if(x2Object)
            Instantiate(x2Object, transform.position + offset , Quaternion.Euler(0,180,0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position +offset,Vector3.one);
    }
}
