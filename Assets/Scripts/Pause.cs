using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [HideInInspector] public static bool pause;
    // Start is called before the first frame update

    private void Start()
    {
        pause = false;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }
    }

    public void SwitchPause()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1;
            QuitButton.quitButton.gameObject.SetActive(false);

        }
        else
        {
            QuitButton.quitButton.gameObject.SetActive(true);
            pause = true;
            Time.timeScale = 0; 

        }
    }
}
