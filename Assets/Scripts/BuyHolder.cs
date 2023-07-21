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

    [SerializeField] private Sprite[] tombstoneSkin;
    [SerializeField] private Vector3 imageShift;
    [SerializeField] private Vector3 spawnShift;

    private GameObject closestObject;
    [HideInInspector] public int tabColor = 0;
    private bool canBuy = false;
    private bool select = false;

    void Start()
    {
        closestObject = ZombieManager.zombieManager.PlaceHolders[0];
        imageRenderer.color /= 2;
        UpdateBuyable();
    }
    public bool GetCanBuy()
    {
        return canBuy;
    }
    public bool GetSelect()
    {
        return select;
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

            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float closestDistance = Mathf.Infinity;
                foreach (GameObject spawn in ZombieManager.zombieManager.PlaceHolders)
                {
                    PlaceHolder spawnComponent = spawn.GetComponent<PlaceHolder>();
                    if (spawnComponent.canSpawn)
                    {
                        if (isAZombie)
                        {   
                            if (tabColor == 0 || (tabColor == 2 && spawnComponent.blueSpawn) || (tabColor == 1 && spawnComponent.redSpawn))
                            {
                                float distance = Vector3.Distance(spawn.transform.position, mousePosition);
                                if (distance < closestDistance)
                                {
                                    closestObject = spawn;
                                    closestDistance = distance;
                                }
                            }
                        }
                        else if (spawnComponent.canBuild)
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
                if(!isAZombie)
                {
                    if (closestObject.GetComponent<PlaceHolder>().distance < 12)
                    {
                        image.GetComponent<SuppCostBrain>().ShowSupp((12 - closestObject.GetComponent<PlaceHolder>().distance) * 25);
                    }
                    else
                    {
                        image.GetComponent<SuppCostBrain>().HideSupp();
                    }
                }
                

            }


        }
    }
    public void ClickMap()
    {
        if(select)
        {
            if (!isAZombie)
            {
                if (ZombieManager.brains >= prices[tabColor] + (12 - closestObject.GetComponent<PlaceHolder>().distance) * 25)
                {
                    ZombieManager.zombieManager.ObtainBrains(-prices[tabColor] - (12 - closestObject.GetComponent<PlaceHolder>().distance) * 25);
                    closestObject.GetComponent<PlaceHolder>().canBuild = false;
                    GameObject instanceSpawn = Instantiate(toBuy[tabColor], image.transform.position, Quaternion.identity);
                    instanceSpawn.GetComponent<BuildHP>().placeHolder = closestObject;
                    instanceSpawn.GetComponent<BuildHP>().distance = closestObject.GetComponent<PlaceHolder>().distance;
                    ZombieManager.zombieManager.AddBuild(instanceSpawn);
                    instanceSpawn.transform.position += spawnShift;
                }
                else
                {
                    return;
                }
            }
            else
            {
                ZombieManager.zombieManager.ObtainBrains(-prices[tabColor]);
                GameObject instanceSpawn = Instantiate(toBuy[tabColor], image.transform.position, Quaternion.identity);
                instanceSpawn.transform.position += spawnShift;

            }
            canBuy = false;
            ResetImage();
            loading.SetActive(false);
            loading.SetActive(true);

        }
    }

    private void OnMouseEnter()
    {
        if (isAZombie)
        {
            ZombieManager.zombieManager.ShowCostZombie(prices[tabColor], toBuy[tabColor].GetComponent<ZombieBehaviour>().Information());
        }
        else
        {
            ZombieManager.zombieManager.ShowCostTomb(prices[tabColor], tabColor);
        }

    }
    private void OnMouseExit()
    {
        ZombieManager.zombieManager.HideCost();
    }

    public void OnMouseClic()
    {
        if (tabColor == 0 || !isAZombie || (tabColor == 2 && HasBlueHolder()) || (tabColor == 1 && HasRedHolder()))
        {
            if (canBuy && prices[tabColor] <= ZombieManager.brains)
            {
                ZombieManager.zombieManager.ResetAllTabs();
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
        foreach (GameObject spawn in ZombieManager.zombieManager.PlaceHolders)
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
        foreach (GameObject spawn in ZombieManager.zombieManager.PlaceHolders)
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
        image.transform.position = transform.position + imageShift*transform.localScale.x;
        if(!isAZombie)
        {
            image.GetComponent<SuppCostBrain>().HideSupp();
        }

    }
    public void ChangeColor(int tabColor)
    {
        this.tabColor = tabColor;
        UpdateBuyable();

        if (loading.activeSelf) {
            canBuy = loading.GetComponent<LoadingHolder>().SetActiveTab(tabColor);
            
        }
        if (!canBuy || isAZombie && ((tabColor == 1 && !HasRedHolder()) || (tabColor == 2 && !HasBlueHolder())))
        {
            ResetImage();
        }
    }

    public void UpdateBuyable()
    {
        if (isAZombie)
        {
            imageRenderer.color = colors[tabColor];
        }
        else
        {
            imageRenderer.color = colors[0];
            imageRenderer.sprite = tombstoneSkin[tabColor];

        }
        if (ZombieManager.brains < prices[tabColor])
        {
            imageRenderer.color /= 2;
        }
        else if(isAZombie && (tabColor == 1 && !HasRedHolder() || tabColor == 2 && !HasBlueHolder()))
        {
            imageRenderer.color /= 2;

        }
    }
}
