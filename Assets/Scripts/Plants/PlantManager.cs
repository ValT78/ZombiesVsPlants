using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantManager : MonoBehaviour
{
    [HideInInspector] public static PlantManager plantManager;

    [SerializeField] private GameObject[] plantTypes; // All prefabs

    [SerializeField] private int[] priceGrid;

    [SerializeField] private PlaceHolder[] placeholders;

    [SerializeField] private TextMeshProUGUI sunMultiplierUI;
    [SerializeField] private TextMeshProUGUI sunCounter;

    [Tooltip("Number of sunflowers gained every 5 seconds")]
    [SerializeField] private int passiveSun;
    

    private int totalSun;

    private int index;
    private int indexPlacement;
    private float sunMultiplier;
    private float plantSpawnTime;

    private int[] plantOrder;
    private int[] plantPlacement;

    private void Awake()
    {
        plantManager = this;
        index = 0;
        indexPlacement = 0;

        
        plantSpawnTime = Transporter.plantSpawnTime;
        sunMultiplier = Transporter.sunMultiplier;
        sunMultiplierUI.text = "x" + sunMultiplier.ToString();
        GetSun(Transporter.startingSun);
        plantOrder = Transporter.plantTable;
        plantPlacement = Transporter.plantPlacement;
        if (Transporter.spawnSuns)
        {
            StartCoroutine(PassiveSun());
        }
        StartCoroutine(PlacePlants());

    }

    private IEnumerator PlacePlants()
    {
        while (true)
        {
            yield return new WaitForSeconds(plantSpawnTime);
            if (priceGrid[plantOrder[index]] <= totalSun)
            {
                InstantiatePlant(plantOrder[index], plantPlacement[indexPlacement]);
                index = (index + 1) % plantOrder.Length;
                indexPlacement = (indexPlacement + 1) % plantPlacement.Length;
            }
        }
    }


    private IEnumerator PassiveSun()
    {
        while (true) {
            yield return new WaitForSeconds(5f/ sunMultiplier);
            GetSun(passiveSun);
            
            yield return new WaitForSeconds(5f/ sunMultiplier);
        }
    }


    public void GetSun(int amount)
	{
        totalSun += amount;
        sunCounter.text = "x" + totalSun.ToString();
    }


    public void InstantiatePlant(int plant, int placement)
    {
        int distance = 12;
        List<PlaceHolder> toPlaces = new();

        foreach (PlaceHolder placeHolder in placeholders)
        {
            if (placeHolder.canBuild)
            {
                if (placement == 0 || placeHolder.lane == placement)
                {
                    if (placeHolder.distance < distance)
                    {
                        distance = placeHolder.distance;
                        toPlaces = new();
                        toPlaces.Add(placeHolder);
                    }
                    else if (placeHolder.distance == distance)
                    {
                        toPlaces.Add(placeHolder);
                    }
                }
            }
        }
        if(toPlaces.Count==0)
        {
            return;
        }
        PlaceHolder toPlace = toPlaces[Random.Range(0,toPlaces.Count)];

        toPlace.canBuild = false;

        GetSun(-priceGrid[plant]);

        GameObject instance = Instantiate(plantTypes[plant], toPlace.gameObject.transform.position, Quaternion.identity);
        instance.GetComponent<BasicPlantBehaviour>().Initialize(toPlace);

    }

    public void KillScript()
    {
        Destroy(this);
    }
}
