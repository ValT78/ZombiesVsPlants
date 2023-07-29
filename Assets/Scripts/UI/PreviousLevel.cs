using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviousLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI previousLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (Transporter.level == -1)
            previousLevel.text = "Last Played Level : None";
        else if (Transporter.level == 0)
            previousLevel.text = "Last Played Level : Tutorial";
        else
            previousLevel.text = "Last Played Level : " + Transporter.level.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
