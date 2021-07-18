using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPlacer : MonoBehaviour
{
    [SerializeField] Transform finger;
    [SerializeField] GameObject clickIndicator;
    [SerializeField]  Vector2 fingerOffset;
    // Start is called before the first frame update
    void Start()
    {
        clickIndicator.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        finger.position = GetScreenPos();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FlashIndicator());
        }
        
    }

    Vector2 GetScreenPos()
    {
        Vector3 posn = Input.mousePosition;
        return new Vector2(posn.x,posn.y) + fingerOffset;
    }

    IEnumerator FlashIndicator()
    {
        clickIndicator.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        clickIndicator.SetActive(false);
    }
}
