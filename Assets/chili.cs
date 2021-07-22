using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class chili : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        CameraShaker.Instance.ShakeOnce(2, 2, 0.1f, 0.1f);
        Destroy(gameObject, 0.2f);
    }
}