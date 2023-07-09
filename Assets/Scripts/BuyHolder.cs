using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHolder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject toBuy;
    [SerializeField] private int price;
    [SerializeField] private float conqueredArea;
    [SerializeField] private int tabColor;
    [SerializeField] private bool isAZombie;
    [SerializeField] private bool isOpen;

    private GameObject closestObject;
    private ZombieManager zombieManager;
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
        if(select)
        {
            if (Input.GetMouseButtonDown(1))
            {
                select = false;
                image.transform.position = transform.position;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                zombieManager.ObtainBrains(-price);
                select = false;
                canBuy = false;
                GameObject instanceSpawn = Instantiate(toBuy, image.transform.position, Quaternion.identity);
                instanceSpawn.transform.position += new Vector3(0, 0.55f, 0);
                closestObject.GetComponent<PlaceHolder>().canBuild = isAZombie;
                if (!isAZombie)
                {
                    foreach (GameObject placeHolder in zombieManager.PlaceHolders)
                    {
                        if(Vector3.Distance(placeHolder.transform.position, image.transform.position) < conqueredArea)
                        {
                            placeHolder.GetComponent<PlaceHolder>().canSpawn = true;
                            instanceSpawn.GetComponent<BuildHP>().distance = placeHolder.GetComponent<PlaceHolder>().distance;
                            if (tabColor==1)
                            {
                                placeHolder.GetComponent<PlaceHolder>().redSpawn = true;

                            }
                            else if (tabColor == 2)
                            {
                                placeHolder.GetComponent<PlaceHolder>().blueSpawn = true;

                            }
                        } 
                    }
                    
                }
                image.transform.position = transform.position;
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
        zombieManager.ShowCost(price);
    }
    private void OnMouseExit()
    {
        zombieManager.HideCost();
    }

    private void OnMouseUp()
    {
        if (isOpen)
        {
            if (tabColor == 0 || !isAZombie || (tabColor == 2 && HasBlueHolder()) || (tabColor == 1 && HasRedHolder()))
            {
                if (canBuy && price <= zombieManager.GetBrains())
                {
                    select = true;
                }
            }
        }
    }
    public void CanBuy()
    {
        canBuy = true;
    }
    public void OpenTab()
    {
        isOpen = true; 
        spriteRenderer.enabled = true;
        col.enabled = true;

    }
    public void CloseTab()
    {
        isOpen = false;
        spriteRenderer.enabled = false;
        col.enabled = false;
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
}
