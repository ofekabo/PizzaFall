using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FingerPlacer : MonoBehaviour
{
    [SerializeField] Transform finger;
    [SerializeField]  Vector2 fingerOffset;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(DisableText());
        StartCoroutine(DisableFinger());
    }

    // Update is called once per frame
    void Update()
    {
        finger.position = GetScreenPos();
    }

    Vector2 GetScreenPos()
    {
        Vector3 posn = Input.mousePosition;
        return new Vector2(posn.x,posn.y) + fingerOffset;
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(5);
        text.enabled = false;
    }
    
    IEnumerator DisableFinger()
    {
        yield return new WaitForSeconds(25);
        finger.gameObject.SetActive(false);
    }
}
