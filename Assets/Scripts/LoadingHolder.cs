using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingHolder : MonoBehaviour
{
    [SerializeField] private BuyHolder buyHolder;
    [SerializeField] private Image loader;
    [SerializeField] private float loadTime;

    private float loadTimer;
    // Start is called before the first frame update
    void Start()
    {
        loadTimer = loadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadTimer<=0f)
        {
            //buyHolder.CanBuy();
            this.gameObject.SetActive(false);
        }
        loader.fillAmount = loadTimer / loadTime;
        loadTimer -= Time.deltaTime;
    }

    
}
