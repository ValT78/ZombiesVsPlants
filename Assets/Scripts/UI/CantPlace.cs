using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CantPlace : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float appearTime;
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;
    private float timer;

    private void OnEnable()
    {
        timer = 0;
        Destroy(gameObject,appearTime);

    }
    void Update()
    {
        timer += Time.deltaTime;
        rectTransform.position = Camera.main.WorldToScreenPoint(minPos + (maxPos - minPos) * timer/appearTime);
        if(timer >= appearTime-0.5)
        {
            text.color = new Color(183,0,0, 1-(timer - appearTime + 0.5f) / 0.5f);
        }
    }
}
