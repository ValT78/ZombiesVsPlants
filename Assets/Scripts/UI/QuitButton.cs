using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlantManager.plantManager.KillScript();
        ZombieManager.zombieManager.KillScript(); 
        SceneManager.LoadScene("AdriKat", LoadSceneMode.Single);

    }
}
