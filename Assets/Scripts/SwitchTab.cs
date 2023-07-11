using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTab : MonoBehaviour
{
    [SerializeField] private int tabColor;
    [SerializeField] private OpenManager openManager;

    void OnMouseUp()
    {
        openManager.Activate(tabColor);
    }
    
}
