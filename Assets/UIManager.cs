using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    [HideInInspector]public int currentNumberSas;
    [HideInInspector]public int currentNumberMush;
    

    private void Start()
    {
        
        currentNumberSas = 0;
        currentNumberMush = 0;
    }


    public void PopMultiplier()
    {
        if (currentNumberSas >= 2)
        {
            Debug.Log(currentNumberSas + " Sasuges multiplier");
        }
        
        if (currentNumberMush >= 2)
        {
            Debug.Log(currentNumberSas + " mushroom multiplier");
        }
    }

    void ShowPopup()
    {
        
    }
 
}
