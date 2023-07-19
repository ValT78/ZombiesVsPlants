using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScreen : MonoBehaviour
{
    [SerializeField] private float floatingTime;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    private float timer;
   

    void Update()
    {
        timer += Time.deltaTime;
        float y = minSize + (Mathf.Sin(timer * floatingTime) + 1) * ((maxSize - minSize) / (2));
        transform.localScale = new (y, y, y);
    }
    
}
