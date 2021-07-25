using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PizzaTriggerHandler : MonoBehaviour
{
    [SerializeField, Range(0,10f)] private float toEmissionStrength;
    [SerializeField] private float delay;
    [SerializeField] private float offsetDelay;
    private float emissionStrength;
    private Material m;
    
    [SerializeField] GameObject tomerPriticle;
    
    private Rigidbody _rb;
    float yVel;
    private void Start()
    {
        m = GetComponent<Renderer>().material;
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        _rb.useGravity = false;
        
        emissionStrength = 0;
        
        m.SetColor("_EmissionColor",m.GetColor("_BaseColor") * emissionStrength);
    }

    private void Update()
    {
        m.SetColor("_EmissionColor",m.GetColor("_BaseColor") * emissionStrength);
        Debug.Log(_rb.velocity.magnitude);
        if (transform.parent.GetComponent<Mover>().gotHit)
        {
           _rb.velocity = Vector3.ClampMagnitude(_rb.velocity,10);
        }
    }

 

    private void TriggerCommand(float emissiveValue)
    {
        LeanTween.value( emissionStrength, emissiveValue, delay).setOnUpdate(value =>
        {
            emissionStrength = value;
        });
    }

    IEnumerator FlashCoro()
    {
        TriggerCommand(toEmissionStrength);
      
        yield return new WaitForSeconds(delay + offsetDelay);
        TriggerCommand(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FlashCoro());
        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.parent.GetComponent<Mover>().gotHit = true;
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }
    
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(tomerPriticle,transform.position,Quaternion.identity);
    }
}
