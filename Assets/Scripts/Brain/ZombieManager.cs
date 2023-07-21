using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject blueSwitch;
    [SerializeField] private TextMeshProUGUI startMessage;

    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level9;
    [SerializeField] private GameObject level10;

    public GameObject[] PlaceHolders = new GameObject[60];

    [HideInInspector] public static List<GameObject> builds;
    [HideInInspector] public static int brains;
    [HideInInspector] public static ZombieManager zombieManager;
    private void Awake()
    {
        zombieManager = this;
        builds = new List<GameObject>();
        brains = startBrains;
        counterText.text = "\nX" + brains.ToString() + "   ";
        StartCoroutine(CollapseMessage());
    }
    

    public void DispawnObject()
    {
        if(Transporter.message==" ")
        {
            tutorial.SetActive(true);
        }
        else if (Transporter.message == "  ")
        {
            level2.SetActive(true);

        }
        else if (Transporter.message == "   ")
        {
            level9.SetActive(true);

        }
        else if (Transporter.message == "    ")
        {
            level10.SetActive(true);

        }
        else
        {
            startMessage.text = Transporter.message;
        }
        if (Transporter.spawnBrains)
        {
            StartCoroutine(PassiveBrains());
        }
        if (Transporter.unlockedZombie < 5)
        {
            blueSwitch.SetActive(false);
            if (Transporter.unlockedZombie < 4)
            {
                OpenManager.openManager.gameObject.SetActive(false);
                if (Transporter.unlockedZombie < 3)
                {
                    buyTabs[5].gameObject.SetActive(false);
                    if (Transporter.unlockedZombie < 2)
                    {
                        buyTabs[4].gameObject.SetActive(false);
                        if (Transporter.unlockedZombie < 1)
                        {
                            buyTabs[3].gameObject.SetActive(false);
                        }
                    }
                }
            }
            else
            {
                OpenManager.openManager.blueTabActive = false;
            }
        }
    }

    private IEnumerator PassiveBrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(timePassiveBrains/(Transporter.sunMultiplier/2f+0.5f));
            SummonGroundBrain();
        }
    }

    private IEnumerator CollapseMessage()
    {
        yield return new WaitForSeconds(20f);
        startMessage.GetComponentInParent<Canvas>().enabled = false;

    }

    public void ObtainBrains(int brains)
    {
        ZombieManager.brains += brains;
        counterText.text = "\nX" + ZombieManager.brains.ToString() + "   ";
        for(int i = 0; i<Mathf.Min(3+Transporter.unlockedZombie,6); i++)
        {
            buyTabs[i].UpdateBuyable();
        }
    }
    
    public void ShowCostZombie(int cost, float[] information)
    {
        brainCostUI.SetActive(true);
        brainCostUI.GetComponentInChildren<TextMeshProUGUI>().text = " HP : "+ information[0].ToString() + "\n Damage : " + information[1].ToString() + "\n Speed : " + information[2].ToString() + "\n Coast : " + cost.ToString();
    }
    public void ShowCostTomb(int cost, int color)
    {
        brainCostUI.SetActive(true);
        if (color == 0)
        {
            brainCostUI.GetComponentInChildren<TextMeshProUGUI>().text = " Create brain\n Expand the\n zombie zone\n Coast : " + cost.ToString();
        }
        else
        {
            brainCostUI.GetComponentInChildren<TextMeshProUGUI>().text = " Create brain\n Allows color\n zombies\n Coast : " + cost.ToString();
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
    public void AddBuild(GameObject build)
    {
        builds.Add(build);
        UpdateHolder(build, true);
        for (int i = 0; i < Mathf.Min(3 + Transporter.unlockedZombie, 6); i++)
        {
            buyTabs[i].UpdateBuyable();
        }
    }

    public void RemoveBuild(GameObject building, GameObject holder, int tabColor)
    {
        holder.GetComponent<PlaceHolder>().canBuild = true;
        builds.Remove(building);
        UpdateHolder(building, false);
        foreach (GameObject build in builds)
        {
            UpdateHolder(build, true);
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
                for(int i = 0; i < Mathf.Min(3 + Transporter.unlockedZombie, 6); i++)
                {
                    if (buyTabs[i].tabColor == 1)
                    {
                        buyTabs[i].ResetImage();
                        buyTabs[i].UpdateBuyable();
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
                for (int i = 0; i < Mathf.Min(3 + Transporter.unlockedZombie, 6); i++)
                {
                    if (buyTabs[i].tabColor == 2)
                    {
                        buyTabs[i].ResetImage();
                        buyTabs[i].UpdateBuyable();
                    }
                }
            }
        }

    }
    private void UpdateHolder(GameObject building,  bool isBuilding)
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
    public void KillScript()
    {
        Destroy(this);
    }
    public void ResetAllTabs()
    {
        for (int i = 0; i < Mathf.Min(3 + Transporter.unlockedZombie, 6); i++)
        {
            buyTabs[i].ResetImage();
        }
    }
}
