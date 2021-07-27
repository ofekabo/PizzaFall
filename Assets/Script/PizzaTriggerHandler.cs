using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTriggerHandler : MonoBehaviour
{
    [SerializeField, Range(0,10f)] private float toEmissionStrength;
    [SerializeField] private float delay;
    [SerializeField] private float offsetDelay;
    private float emissionStrength;
    private Material m;
    private void Start()
    {
        m = GetComponent<Renderer>().material;
        
        emissionStrength = 0;
        
        m.SetColor("_EmissionColor",m.GetColor("_BaseColor") * emissionStrength);
    }

    private void Update()
    {
        m.SetColor("_EmissionColor",m.GetColor("_BaseColor") * emissionStrength);
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
    }
}
