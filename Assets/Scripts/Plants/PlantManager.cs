using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlantManager : MonoBehaviour
{
    [HideInInspector] public static PlantManager plantManager;

    public GameObject[] plantTypes; // All prefabs

    public int[] priceGrid;

    public PlaceHolder[] placeholders;

    [SerializeField] private TextMeshProUGUI sunMultiplierUI;
    [SerializeField] private TextMeshProUGUI sunCounter;

    [Tooltip("Number of sunflowers gained every 5 seconds")]
    public int passiveSun;
    [Tooltip("Average duration (in seconds) between which plants are being planted")]
    public float averageTimeBetweenPlants;


    public int totalSun;

    private int index;
    private float sunMultiplier;
    private float plantSpawnTime;

    public int[] plantOrder;

    private void Awake()
    {
        plantManager = this;
        index = 0;

        StartCoroutine(PassiveSun());
        StartCoroutine(PlacePlants());

        plantSpawnTime = Transporter.plantSpawnTime;
        sunMultiplier = Transporter.sunMultiplier;
        sunMultiplierUI.text = "x" + sunMultiplier.ToString();
        totalSun = Transporter.startingSun;
        sunCounter.text = "x" + totalSun.ToString();
        plantOrder = Transporter.plantTable;

    }

    private IEnumerator PlacePlants()
    {
        while (true)
        {
            yield return new WaitForSeconds(plantSpawnTime);
            if (priceGrid[plantOrder[index]] <= totalSun)
            {
                GetSun(-priceGrid[plantOrder[index]]);
                InstantiatePlant(plantOrder[index]);
                index = (index + 1) % plantOrder.Length;
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


    public void InstantiatePlant(int plant)
    {
        int distance = 12;
        List<PlaceHolder> toPlaces;
        toPlaces = new();

        foreach (PlaceHolder placeHolder in placeholders)
        {
            if (placeHolder.canBuild)
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
        PlaceHolder toPlace = toPlaces[Random.Range(0,toPlaces.Count)];

        toPlace.canBuild = false;

        GameObject instance = Instantiate(plantTypes[plant], toPlace.gameObject.transform.position, Quaternion.identity);
        instance.GetComponent<BasicPlantBehaviour>().Initialize(toPlace);

    }

    public void KillScript()
    {
        Destroy(this);
    }
}
