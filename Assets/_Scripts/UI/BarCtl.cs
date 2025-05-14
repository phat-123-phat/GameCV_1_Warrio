using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCtl : MonoBehaviour
{
    public Image fillBar;
    
    public void UpdateBar (int currentVal, int maxVal)
    {
        fillBar.fillAmount = currentVal / maxVal;   
    }    
}
