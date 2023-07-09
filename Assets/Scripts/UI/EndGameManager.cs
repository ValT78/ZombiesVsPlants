using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    public float targetScale;


    private int framesCount;
    private float currentScale;
    void Start()
    {
        framesCount = 0;
        currentScale = 0;
        transform.localScale = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        currentScale += (targetScale - currentScale) / 60;
        transform.localScale = new Vector3(currentScale, currentScale, 1);
        
     
        framesCount++;

		if (framesCount>=360)
		{
            SceneManager.LoadScene("Menu");
		}
    }
}
