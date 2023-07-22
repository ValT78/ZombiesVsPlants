using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    public float targetScale;


    private float currentScale;
    void Start()
    {
        PlantManager.plantManager.KillScript();
        ZombieManager.zombieManager.KillScript();
        currentScale = 0;
        transform.localScale = new Vector3(0, 0, 1);
        StartCoroutine(EndLevel());
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        currentScale += (targetScale - currentScale) / 60;
        transform.localScale = new Vector3(currentScale, currentScale, 1);
        
     

    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("AdriKat", LoadSceneMode.Single);
    }
}
