using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionMenu;
    private void OnMouseDown()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
}
