using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody _rb;
    [HideInInspector] public bool gotHit;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gotHit = false;
    }

    void Update()
    {
        if (gotHit)
        {
            _rb.useGravity = true;
            return;
        }
        _rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            gotHit = true;
        }
    }
}
