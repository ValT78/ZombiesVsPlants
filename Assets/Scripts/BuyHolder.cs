using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHolder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer imageRenderer;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject image;

    [SerializeField] private GameObject[] toBuy;
    [SerializeField] private int[] prices;
    [SerializeField] private Color[] colors;

    [SerializeField] private float conqueredArea;
    [SerializeField] private bool isAZombie;
    [SerializeField] private bool isOpen;

    private GameObject closestObject;
    private ZombieManager zombieManager;
    [HideInInspector] public int tabColor;
    private bool canBuy = false;
    private bool select = false;

    void Start()
    {
        zombieManager = FindObjectOfType<ZombieManager>();
        closestObject = zombieManager.PlaceHolders[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (select)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ResetImage();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                zombieManager.ObtainBrains(-prices[tabColor]);
                canBuy = false;
                GameObject instanceSpawn = Instantiate(toBuy[tabColor], image.transform.position, Quaternion.identity);
                instanceSpawn.transform.position += new Vector3(0, 0.55f, 0);
                if (!isAZombie)
                {
                    closestObject.GetComponent<PlaceHolder>().canBuild = false;
                    instanceSpawn.GetComponent<BuildHP>().placeHolder = closestObject;
                    instanceSpawn.GetComponent<BuildHP>().distance = closestObject.GetComponent<PlaceHolder>().distance;
                    zombieManager.AddBuild(instanceSpawn, tabColor);
                }
                
                ResetImage();
                loading.SetActive(false);
                loading.SetActive(true);

            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float closestDistance = Mathf.Infinity;
                foreach (GameObject spawn in zombieManager.PlaceHolders)
                {
                    if (spawn.GetComponent<PlaceHolder>().canSpawn)
                    {
                        if (isAZombie)
                        {
                            if (tabColor == 0 || (tabColor == 2 && spawn.GetComponent<PlaceHolder>().blueSpawn) || (tabColor == 1 && spawn.GetComponent<PlaceHolder>().redSpawn))
                            {
                                float distance = Vector3.Distance(spawn.transform.position, mousePosition);
                                if (distance < closestDistance)
                                {
                                    closestObject = spawn;
                                    closestDistance = distance;
                                }
                            }
                        }
                        else if (spawn.GetComponent<PlaceHolder>().canBuild)
                        {
                            float distance = Vector3.Distance(spawn.transform.position, mousePosition);
                            if (distance < closestDistance)
                            {
                                closestObject = spawn;
                                closestDistance = distance;
                            }
                        }
                    }
                }
                image.transform.position = closestObject.transform.position;
            }


        }
    }
    private void OnMouseEnter()
    {
        zombieManager.ShowCost(prices[tabColor]);
        
    }
    private void OnMouseExit()
    {
        zombieManager.HideCost();
    }

    public void OnMouseClic()
    {
        if (tabColor == 0 || !isAZombie || (tabColor == 2 && HasBlueHolder()) || (tabColor == 1 && HasRedHolder()))
        {
            if (canBuy && prices[tabColor] <= zombieManager.GetBrains())
            {
                select = true;
            }
        }
    }

    public void CanBuy()
    {
        canBuy = true;
    }
    private bool HasBlueHolder()
    {
        foreach (GameObject spawn in zombieManager.PlaceHolders)
        {
            if(spawn.GetComponent<PlaceHolder>().blueSpawn)
            {
                return true;
            }
        }
        return false;

    }
    private bool HasRedHolder()
    {
        foreach (GameObject spawn in zombieManager.PlaceHolders)
        {
            if (spawn.GetComponent<PlaceHolder>().redSpawn)
            {
                return true;
            }
        }
        return false;

    }
    public void ResetImage()
    {
        select = false;
        image.transform.position = transform.position;
    }
    public void ChangeColor(int tabColor)
    {
        this.tabColor = tabColor;
        spriteRenderer.color = colors[tabColor];
        if(isAZombie)
        {
            imageRenderer.color = colors[tabColor];

        }
        else
        {
            imageRenderer.color = colors[tabColor];

        }
        if (loading.activeSelf) {
            canBuy = loading.GetComponent<LoadingHolder>().SetActiveTab(tabColor);
            
        }
        if (!canBuy || (tabColor == 1 && !HasRedHolder()) || (tabColor == 2 && !HasBlueHolder()))
        {
            ResetImage();
        }
    }
}
