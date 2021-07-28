using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private ParticleSystem _pps;

    private Rigidbody _rb;
    [HideInInspector] public bool gotHit;
    private Outline _outline;

    //[InitializeOnLoadMethod]
    private void CompEditor()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        gotHit = false;
        _outline = GetComponent<Outline>();
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        gotHit = false;
        _outline = GetComponent<Outline>();
    }

    private void Update()

    {
        if (!gotHit)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            return;
        }

        // void FixedUpdate()
        // {
        //
        //     if (gotHit)
        //     {
        //         _rb.useGravity = true;
        //         // float maxVelY = Mathf.Clamp(_rb.velocity.y,-15,2);
        //         // _rb.velocity = new Vector3(_rb.velocity.x,maxVelY,_rb.velocity.z);
        //         return;
        //     }
        //     _rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * speed);
        //     
        // }
        _rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            gotHit = true;
            Instantiate(_pps, transform.position, _pps.transform.rotation);
            _outline.enabled = false;
        }
    }
}