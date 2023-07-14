using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTabs : MonoBehaviour
{
    [SerializeField] private BuyHolder[] tabs;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ResetEveryTabs();
            tabs[0].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ResetEveryTabs();
            tabs[1].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            ResetEveryTabs();
            tabs[2].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            ResetEveryTabs();
            tabs[3].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            ResetEveryTabs();
            tabs[4].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            ResetEveryTabs();
            tabs[5].OnMouseClic();
        }
    }
    private void ResetEveryTabs()
    {
        foreach(BuyHolder tab in tabs)
        {
            tab.ResetImage();
        }
    }
}
