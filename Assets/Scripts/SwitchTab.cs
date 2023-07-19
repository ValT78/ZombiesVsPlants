using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTab : MonoBehaviour
{
    [SerializeField] private int tabColor;

    public void OnClick()
    {
        OpenManager.openManager.Activate(tabColor);
    }
    
}
