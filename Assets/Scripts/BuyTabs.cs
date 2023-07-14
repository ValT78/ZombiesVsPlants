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
        else if (Input.GetKeyDown(KeyCode.J) && tabs[3].gameObject.activeSelf)
        {
            ResetEveryTabs();
            tabs[3].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.K) && tabs[4].gameObject.activeSelf)
        {
            ResetEveryTabs();
            tabs[4].OnMouseClic();
        }
        else if (Input.GetKeyDown(KeyCode.L) && tabs[5].gameObject.activeSelf)
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
