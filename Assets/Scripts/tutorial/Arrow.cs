using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float movingTime;
    [SerializeField] private float xx;
    [SerializeField] private float yy;
    private Vector3 minPos;
    private Vector3 maxPos;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = minPos + (maxPos - minPos) * (Mathf.Sin(timer*movingTime)+1)/2 + new Vector3(960f+xx,540f+yy,0f);
    }
    public void SetPos(Vector3 minPos, Vector3 maxPos)
    {
        this.minPos = minPos;
        this.maxPos = maxPos;
    }
}
