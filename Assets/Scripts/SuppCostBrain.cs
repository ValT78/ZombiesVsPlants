using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SuppCostBrain : MonoBehaviour
{
    [SerializeField] private GameObject brain;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject toFollow;
    // Start is called before the first frame update
   
    public void ShowSupp(int brains)
    {
        brain.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "+" + brains.ToString();
        text.rectTransform.position = Camera.main.WorldToScreenPoint(toFollow.transform.position);

    }
    public void HideSupp()
    {
        brain.SetActive(false);
        text.gameObject.SetActive(false);
    }
}
