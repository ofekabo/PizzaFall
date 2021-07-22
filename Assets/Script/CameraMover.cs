using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform pizza;
    public float _distanceToPizza;


    void Update()
    {
        transform.position =
            new Vector3(transform.position.x, pizza.position.y + _distanceToPizza, transform.position.z);
    }
}