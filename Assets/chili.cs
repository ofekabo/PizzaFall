using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using UnityEngine.Rendering;

public class chili : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private VolumeProfile fireVolume;
    [SerializeField] private VolumeProfile normalVolume;
    [SerializeField] private Volume _volumeProfile;
    
    private void OnTriggerEnter(Collider other)
    {
        CameraShaker.Instance.ShakeOnce(2, 2, 0.1f, 0.1f);
        StartCoroutine(FireEffect());
    }

    IEnumerator FireEffect()
    {
        fire.SetActive(true);
        _volumeProfile.profile = fireVolume;
        yield return new WaitForSeconds(3f);
        fire.SetActive(false);
        _volumeProfile.profile = normalVolume;
    }
}