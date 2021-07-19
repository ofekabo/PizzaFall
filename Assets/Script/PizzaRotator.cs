using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PizzaRotator : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        // Vector3 dir = Camera.main.WorldToScreenPoint(GetMousePos());
        // Debug.Log(GetMousePos());
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        // transform.rotation = Quaternion.Euler(90, angle, 0);
        Vector3 dir = GetMousePos() - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.down);

        // Quaternion targetRotation = Quaternion.Euler(90,angle,0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation , Time.deltaTime * 3);
        // transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
    }

    Vector3 GetMousePos()
    {
        return new Vector3(Input.mousePosition.x, Input.mousePosition.y,transform.position.z);
    }
}

