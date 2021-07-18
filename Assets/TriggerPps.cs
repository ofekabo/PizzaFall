using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TriggerPps : MonoBehaviour
{
    [SerializeField] private ParticleSystem pps;
    [SerializeField] private PlayableDirector _director;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(pps, transform.position, pps.transform.rotation);
        _director.Play();
    }
}
