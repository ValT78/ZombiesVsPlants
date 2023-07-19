using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenManager : MonoBehaviour
{
    [SerializeField] private BuyHolder[] tabs;
    [HideInInspector] public static OpenManager openManager;

    public bool blueTabActive;
    private void Awake()
    {
        openManager = this;
    }

    void Update()
    {
        if(blueTabActive && Input.GetKeyDown(KeyCode.Q))
        {
            Activate(2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Activate(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Activate(0);
        }
    }
    public void Activate(int tabColor)
    {
        foreach (BuyHolder tab in tabs)
        {
            tab.ChangeColor(tabColor);

        }
    }
}
