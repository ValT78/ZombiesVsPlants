using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHolder : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject toBuy;
    [SerializeField] private int price;
    [SerializeField] private float conqueredArea;
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
                image.transform.position = Vector3.zero;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                zombieManager.ObtainBrains(-price);
                select = false;
                canBuy = false;
                Instantiate(toBuy, image.transform.position, Quaternion.identity);
                closestObject.GetComponent<PlaceHolder>().canBuild = isAZombie;
                if (!isAZombie)
                {
                    foreach (GameObject placeHolder in zombieManager.PlaceHolders)
                    {
                        if(Vector3.Distance(placeHolder.transform.position, image.transform.position) < conqueredArea)
                        {
                            placeHolder.GetComponent<PlaceHolder>().canSpawn = true;
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
                    if (spawn.GetComponent<PlaceHolder>().canSpawn && ( isAZombie || spawn.GetComponent<PlaceHolder>().canBuild))
                    {
                        float distance = Vector3.Distance(spawn.transform.position, mousePosition);
                        if (distance < closestDistance)
                        {
                            closestObject = spawn;
                            closestDistance = distance;
                        }
                    }
                }
                image.transform.position = closestObject.transform.position;
            }


        }
    }

    private void OnMouseUp()
    {
        if (isOpen)
        {
            if (canBuy && price <= zombieManager.GetBrains())
            {
                select = true;
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

    }
    public void CloseTab()
    {
        isOpen = false;
        spriteRenderer.enabled = false;

    }
}
