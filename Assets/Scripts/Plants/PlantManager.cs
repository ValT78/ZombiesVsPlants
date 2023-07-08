using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

    public GameObject[] plantTypes; // All prefabs

    public int[] priceGrid;

    private GameObject[,] plantMatrix = new GameObject[5, 12];

    public ZombieManager zombieManager;

    [Tooltip("Number of sunflowers to start with")]
    public int startingSun;
    [Tooltip("Number of sunflowers gained every 5 seconds")]
    public int passiveSun;
    [Tooltip("Average duration (in seconds) between which plants are being planted")]
    public float averageTimeBetweenPlants;


    private int totalSun;

    private int framesCount;


    void Start()
    {
        Application.targetFrameRate = 60;

        totalSun = startingSun;

        if (priceGrid.Length != plantTypes.Length)
            Debug.LogError("Price Grid and plant types must have the same length !");


        InstantiatePlant(5, 0, 0);

		/*for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 12; j++)
			{
				InstantiatePlant(0, i, j);
			}
		}*/
	}

    void Update()
    {
		if (framesCount % 350 == 0)
		{
            GetSun(passiveSun);
		}
    }

    public void GetSun(int amount)
	{
        totalSun += amount;
	}


    public bool InstantiatePlant(int plant, int linePos, int columnPos)
    {
        if(plantMatrix[linePos,columnPos] != null)
		{
            Debug.LogError("Can't spawn a plant on top of an existing plant !");
            return false;
		}

		if (totalSun - priceGrid[plant] < 0)
		{
            Debug.LogError("Not enough sun to plant !");
            return false;
        }


        GameObject instance = Instantiate(plantTypes[plant], new Vector3(columnPos, linePos, 0), Quaternion.identity);
        instance.GetComponent<BasicPlantBehaviour>().Initialize(this, zombieManager, linePos, columnPos);
        plantMatrix[linePos, columnPos] = instance;
        return true;
    }

    public void FreePlantPlaceHolder(int linePos, int columnPos)
	{
        plantMatrix[linePos, columnPos] = null;
    }
}
