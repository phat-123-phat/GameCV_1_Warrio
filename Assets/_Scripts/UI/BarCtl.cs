using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCtl : MonoBehaviour
{
    public Image fillBar;
    
    public void UpdateBar (float currentVal, float maxVal)
    {
        fillBar.fillAmount = currentVal / maxVal;   
    }    
}
