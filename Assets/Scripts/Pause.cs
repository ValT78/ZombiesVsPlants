using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [HideInInspector] public static bool pause;
    [SerializeField] private GameObject quitButton;
    // Start is called before the first frame update

    private void Awake()
    {
        pause = false;
        Time.timeScale = Transporter.gameSpeed;
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
            Time.timeScale = Transporter.gameSpeed;
            quitButton.SetActive(false);

        }
        else
        {
            quitButton.SetActive(true);
            pause = true;
            Time.timeScale = 0; 

        }
    }
}
