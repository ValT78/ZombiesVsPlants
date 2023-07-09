using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenManager : MonoBehaviour
{
    [SerializeField] private SwitchTab classicTab;
    [SerializeField] private SwitchTab redTab;
    [SerializeField] private SwitchTab blueTab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            blueTab.Activate();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            redTab.Activate();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            classicTab.Activate();
        }
    }
}
