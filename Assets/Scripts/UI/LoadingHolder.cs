using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingHolder : MonoBehaviour
{
    [SerializeField] private BuyHolder buyHolder;
    [SerializeField] private Image loader;
    [SerializeField] private float[] reloadTimes;

    private int activeTab;
    private float[] reloadTimer = new float[3];
    private bool flag;

    private void Start()
    {
        activeTab = 0;
        reloadTimer[0] = reloadTimes[0] / 2;
        reloadTimer[1] = reloadTimes[1] / 2;
        reloadTimer[2] = reloadTimes[2] / 2;
    }
    void OnEnable()
    {
        activeTab = buyHolder.tabColor;
        reloadTimer[activeTab] = 0;
    }

    void Update()
    {
        flag = true;
        for (int i = 0; i < 3; i++)
        {
            if (reloadTimer[i] < reloadTimes[i])
            {
                reloadTimer[i] += Time.deltaTime; 
                flag = false;
            }
            
        }
        if (flag)
        {
            this.gameObject.SetActive(false);
        }
        if (reloadTimer[activeTab] < reloadTimes[activeTab])
        {
            loader.fillAmount = 1 - reloadTimer[activeTab] / reloadTimes[activeTab];
        }
        else
        {
            loader.fillAmount = 0;
            buyHolder.CanBuy();
        }

    }
    public bool SetActiveTab(int i)
    {
        activeTab = i;
        if(reloadTimer[activeTab] >= reloadTimes[activeTab])
        {
            return true;
        }
        return false;

    }


}
