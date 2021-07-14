using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TriggerPps : MonoBehaviour
{
    [SerializeField] private ParticleSystem pps;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(pps, transform.position, quaternion.identity);
    }
}
