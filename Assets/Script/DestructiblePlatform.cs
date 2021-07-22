using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatform : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private bool Left;
    [SerializeField] private bool Right;
    [SerializeField] private float power;
    [SerializeField] float dissolveTime;
    
    private Material _m;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _m = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rigidbody.isKinematic = false;
            if (Left)
                _rigidbody.AddForce(Vector3.left * power + Vector3.down, ForceMode.Impulse);
            if (Right)
                _rigidbody.AddForce(Vector3.right * power+ Vector3.down, ForceMode.Impulse);
            
            LeanTween.value(_m.GetFloat("_DissAmount"),1,dissolveTime).setOnUpdate(value =>
            {
               _m.SetFloat("_DissAmount",value); 
            });
        }
    }
}