using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody _rb;
    [HideInInspector] public bool gotHit;

    [InitializeOnLoadMethod]
    private void CompEditor()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        gotHit = false;
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        gotHit = false;
    }

    void FixedUpdate()
    {

        if (gotHit)
        {
            _rb.useGravity = true;
            // float maxVelY = Mathf.Clamp(_rb.velocity.y,-15,2);
            // _rb.velocity = new Vector3(_rb.velocity.x,maxVelY,_rb.velocity.z);
            return;
        }
        _rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * speed);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (other.collider.CompareTag("Obstacle"))
        // {
            gotHit = true;
        // }
    }
}
