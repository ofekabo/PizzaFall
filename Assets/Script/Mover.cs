using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private ParticleSystem _pps;

    private Rigidbody _rb;
     public bool gotHit;
    private Outline _outline;

    [InitializeOnLoadMethod]
    private void CompEditor()
    {
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        _outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if (gotHit) 
        {
            return;
        }
        
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            gotHit = true;
            _rb.isKinematic = false;
            _rb.useGravity = true;
            Debug.Log("HIT");
            if(_pps)
                Instantiate(_pps, transform.position, _pps.transform.rotation);
            _outline.enabled = false;
        }
    }
}