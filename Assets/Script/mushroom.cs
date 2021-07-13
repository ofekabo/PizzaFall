using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _meshRenderer.enabled = false;
        StartCoroutine(SlowMO());
    }

    private IEnumerator SlowMO()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
