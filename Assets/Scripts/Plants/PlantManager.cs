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


    public int totalSun;

    private int framesCount;

    private int index;

    private float randomSeed;


    //********************************************


    public int[] plantOrder = {0,3,3,0,3,0,2,3,0,3,0,3,3,3,2}; // Corresponds to the "PlantType" ENUM stored in BasicPlantBehaviour


    //********************************************



    void Start()
    {
        Application.targetFrameRate = 60;

        index = 0;
        totalSun = startingSun;

        if (priceGrid.Length != plantTypes.Length)
            Debug.LogError("Price Grid and plant types must have the same length !");


        /*for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 12; j++)
			{
				InstantiatePlant(0, i, j);
			}
		}*/

        randomSeed = Random.Range(0, 50);

	}

    void Update()
    {
		if (framesCount % 720 == 0)
		{
            GetSun(passiveSun);
		}

        if(framesCount% (int)(averageTimeBetweenPlants*30 + randomSeed) == 0)
		{

            //Debug.Log("Trying to plant at frame "+framesCount);

            int[] pos = GetRandomNextFreePosition();

			if (InstantiatePlant(plantOrder[index], pos[0], pos[1]) || Random.Range(0f, 1f) > 0.96)
			{
                index = (index+1)%plantOrder.Length;
                //Debug.Log("Skipped a plant !");
			}

            randomSeed = Random.Range(0, 50);
        }

        framesCount++;
    }

    
    private int[] GetRandomNextFreePosition()
	{
        int i = Random.Range(0,5);
        int j = 0;

        int sat = 0;

		while (plantMatrix[i, j] != null)
		{
            i = Random.Range(0, 5);
            sat += 1;

            j = sat % 6;
        }

        return new int[] { i, j };
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
            //Debug.LogError("Not enough sun to plant !");
            return false;
        }


        GameObject instance = Instantiate(plantTypes[plant], new Vector3(columnPos, linePos, 0), Quaternion.identity);
        instance.GetComponent<BasicPlantBehaviour>().Initialize(this, zombieManager, linePos, columnPos);
        plantMatrix[linePos, columnPos] = instance;

        totalSun -= priceGrid[plant];

        return true;
    }

    public void FreePlantPlaceHolder(int linePos, int columnPos)
	{
        plantMatrix[linePos, columnPos] = null;
    }
}
