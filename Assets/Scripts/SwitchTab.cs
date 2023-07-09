using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTab : MonoBehaviour
{
    [SerializeField] private GameObject mainTab;
    [SerializeField] private GameObject otherTab1;
    [SerializeField] private GameObject otherTab2;

    void OnMouseUp()
    {
        Activate();
    }
    public void Activate()
    {
        for (int i = 0; i < mainTab.transform.childCount; i++)
        {
            Transform child = mainTab.transform.GetChild(i);
            child.GetComponent<BuyHolder>().OpenTab();
            child.GetChild(0).GetComponent<ModifyCanvas>().MakeVisible();
            child.GetChild(1).gameObject.SetActive(true);

        }
        for (int i = 0; i < otherTab1.transform.childCount; i++)
        {
            Transform child = otherTab1.transform.GetChild(i);
            child.GetComponent<BuyHolder>().CloseTab();
            child.GetChild(0).GetComponent<ModifyCanvas>().MakeInvisible();
            child.GetChild(1).gameObject.SetActive(false);

        }
        for (int i = 0; i < otherTab2.transform.childCount; i++)
        {
            Transform child = otherTab2.transform.GetChild(i);
            child.GetComponent<BuyHolder>().CloseTab();
            child.GetChild(0).GetComponent<ModifyCanvas>().MakeInvisible();
            child.GetChild(1).gameObject.SetActive(false);

        }
    }
}
