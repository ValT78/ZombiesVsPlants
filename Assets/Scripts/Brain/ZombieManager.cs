using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] private GameObject shinyBrainPrefab;

    [SerializeField] private int startBrains;
    [SerializeField] private float timePassiveBrains;
    public List<GameObject> goldenBrains;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private GameObject brainCostUI;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private BuyHolder[] buyTabs;


    public GameObject[] PlaceHolders = new GameObject[60];
    private int brains;
    void Start()
    {
        //goldenBrains = new List<GameObject>();
        brains = startBrains;
        StartCoroutine(PassiveBrains());
        counterText.text = "\nX" + this.brains.ToString() + "   ";

    }

    private IEnumerator PassiveBrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(timePassiveBrains);
            SummonGroundBrain();
        }
    }

    public void ObtainBrains(int brains)
    {
        this.brains += brains;
        counterText.text = "\nX" + this.brains.ToString() + "   ";
    }
    public int GetBrains()
    {
        return brains;
    }
    public void ShowCost(int cost)
    {
        brainCostUI.SetActive(true);
        brainCostUI.GetComponentInChildren<TextMeshProUGUI>().text = "\nCoût : " + cost.ToString();

        foreach(BuyHolder tab in buyTabs)
        {
            tab.ResetImage();
        }
    }
    public void HideCost()
    {
        brainCostUI.SetActive(false);
    }
    private void SummonGroundBrain()
    {
        GameObject shinyBrain = Instantiate(shinyBrainPrefab, new Vector2(Random.Range(-15, 15), -10f), Quaternion.identity);
        shinyBrain.GetComponent<BrainItem>().SetFromGround(true);
    }

    public void CheckVictory()
    {
        StartCoroutine(DelayVictory());
    }
    private IEnumerator DelayVictory()
    {
        yield return new WaitForSeconds(0.2f);
        print(goldenBrains.Count);
        if (goldenBrains.Count <= 0)
        {
            Instantiate(victoryScreen, Vector3.zero, Quaternion.identity);
        }
    }
}
