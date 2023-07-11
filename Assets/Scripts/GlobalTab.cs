using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTab : MonoBehaviour
{
    [SerializeField] private BuyHolder[] everyTab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        foreach(BuyHolder tab in everyTab)
        {
            tab.ResetImage();
        }
    }

}
