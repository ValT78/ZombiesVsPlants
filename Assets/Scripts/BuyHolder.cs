using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHolder : MonoBehaviour
{
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject toBuy;
    [SerializeField] private int price;

    private ZombieManager zombieManager;
    private bool canBuy = false;
    private bool select = false;

    void Start()
    {
        zombieManager = FindObjectOfType<ZombieManager>();
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
                image.transform.position = transform.position;
                loading.SetActive(true);
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 closestObject = Vector3.positiveInfinity;
                float closestDistance = Mathf.Infinity;
                foreach (Transform spawn in zombieManager.availableSpawn)
                {
                    float distance = Vector3.Distance(spawn.position, mousePosition);

                    // Vérifier si la distance est plus proche que la distance actuelle
                    if (distance < closestDistance)
                    {
                        closestObject = spawn.position;
                        closestDistance = distance;
                    }
                }
                image.transform.position = closestObject;
            }


        }
    }

    private void OnMouseUp()
    {
        if(canBuy && price<=zombieManager.GetBrains())
        {
            select = true;
        }
    }

    public void CanBuy()
    {
        canBuy = true;
        print(canBuy);
    }
}
