using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EmissiveControl : MonoBehaviour
{
    [SerializeField] private Material mat;
    [Range(0.0f,0.3f)]
    [SerializeField] private float value;

    private void Update()
    {
        mat.SetColor("_EmissionColor",new Color(255,255,255,0.5f) * value);
    }
}
