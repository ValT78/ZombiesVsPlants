using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] private GameObject shinyBrainPrefab;

    [SerializeField] private int startBrains;
    [SerializeField] private float timePassiveBrains;
    [SerializeField] private float conqueredArea;
    public List<GameObject> goldenBrains;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private GameObject brainCostUI;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private BuyHolder[] buyTabs;


    public GameObject[] PlaceHolders = new GameObject[60];

    private List<GameObject> builds;
    private int brains;
    void Start()
    {
        builds = new List<GameObject>();
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
        if (goldenBrains.Count <= 0)
        {
            Instantiate(victoryScreen, Vector3.zero, Quaternion.identity);
        }
    }
    public void AddBuild(GameObject build, int tabColor)
    {
        builds.Add(build);
        UpdateHolder(build, tabColor,true);
    }

    public void RemoveBuild(GameObject building, GameObject holder, int tabColor)
    {
        holder.GetComponent<PlaceHolder>().canBuild = true;
        builds.Remove(building);
        UpdateHolder(building, tabColor, false);
        foreach (GameObject build in builds)
        {
            UpdateHolder(build, tabColor, true);
        }
        if (tabColor == 1)
        {
            bool flag = false;
            foreach (GameObject spawn in PlaceHolders)
            {
                if (spawn.GetComponent<PlaceHolder>().redSpawn)
                {
                    flag = true;
                }
            }
            if(!flag)
            {
                foreach (BuyHolder tab in buyTabs)
                {
                    if (tab.tabColor == 1)
                    {
                        tab.ResetImage();
                    }
                }
            }
        }
        if (tabColor == 2)
        {
            bool flag = false;
            foreach (GameObject spawn in PlaceHolders)
            {
                if (spawn.GetComponent<PlaceHolder>().blueSpawn)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                foreach (BuyHolder tab in buyTabs)
                {
                    if (tab.tabColor == 2)
                    {
                        tab.ResetImage();
                    }
                }
            }
        }

    }
    private void UpdateHolder(GameObject building, int tabColor, bool isBuilding)
    {
        foreach (GameObject placeHolder in PlaceHolders)
        {
            if (Vector3.Distance(placeHolder.transform.position, building.transform.position) < conqueredArea)
            {
                PlaceHolder component = placeHolder.GetComponent<PlaceHolder>();
                if(component.distance!=12)
                {
                    component.canSpawn = isBuilding;
                }
                if (building.GetComponent<BuildHP>().color == 1)
                {
                    component.redSpawn = isBuilding;
                    
                }
                else if (building.GetComponent<BuildHP>().color == 2)
                {
                    component.blueSpawn = isBuilding;

                }
            }
        }
        

    }
}
