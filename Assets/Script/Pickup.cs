using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    

    private void OnTriggerEnter(Collider other)
    {
        // pizzaMaterial.SetTexture("_MainTex",_texture);
        other.GetComponent<Renderer>().material.mainTexture = _texture;
        Instantiate(ppSystem, transform.position,quaternion.identity);
        if (x2Object)
        {
            GameObject multiplier = Instantiate(x2Object, transform.position + offset , Quaternion.Euler(90,0,0));
            LeanTween.scale(multiplier, Vector3.one * 2, 0.1f).setEaseOutBounce();
            StartCoroutine(ReturnToScale(multiplier));

        }
           
        Destroy(gameObject);
    }

    IEnumerator ReturnToScale(GameObject multiplier)
    {
        yield return new WaitForSeconds(0.1f);
        LeanTween.scale(multiplier, Vector3.one, 0.1f).setEaseOutExpo();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position +offset,Vector3.one);
    }
}
