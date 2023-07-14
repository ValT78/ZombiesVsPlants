using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlantManager : MonoBehaviour
{

    public GameObject[] plantTypes; // All prefabs

    public int[] priceGrid;

    private GameObject[,] plantMatrix = new GameObject[5, 12];

    public GameObject[] placeholdersMatrix;

    public ZombieManager zombieManager;
    [SerializeField] private TextMeshProUGUI sunMultiplierUI;

    [Tooltip("Number of sunflowers to start with")]
    public int startingSun;
    [Tooltip("Number of sunflowers gained every 5 seconds")]
    public int passiveSun;
    [Tooltip("Average duration (in seconds) between which plants are being planted")]
    public float averageTimeBetweenPlants;


    public float sunMultiplier;

    public int totalSun;

    private int framesCount;

    private int index;

    private float randomSeed;

    public int[] plantOrder;



    

    void Start()
    {
        Application.targetFrameRate = 60;
        
        index = 0;
        totalSun = startingSun;

        if (priceGrid.Length != plantTypes.Length)
            Debug.LogError("Price Grid and plant types must have the same length !");

        randomSeed = Random.Range(0, 50);
        sunMultiplierUI.text = "X" + this.sunMultiplier.ToString();

        StartCoroutine(PassiveSun());
	}
    
    void Update()
    {

        if(framesCount% (int)(averageTimeBetweenPlants*30 + randomSeed) == 0)
		{

            //Debug.Log("Trying to plant at frame "+framesCount);

            int[] pos = GetRandomNextFreePosition();

			if (InstantiatePlant(plantOrder[index], pos[0], pos[1]))
			{
                index = (index+1)%plantOrder.Length;
                //Debug.Log("Skipped a plant !");
			}

            randomSeed = Random.Range(0, 50);
        }

        framesCount++;
    }

    private IEnumerator PassiveSun()
    {
        while (true) {
            yield return new WaitForSeconds(10/sunMultiplier);
            GetSun(passiveSun);
            yield return new WaitForSeconds(10 / sunMultiplier);
        }
    }

    
    private int[] GetRandomNextFreePosition()
	{
        int i = Random.Range(0,5);
        int j = 0;

        int sat = 0;

		while (j < 12 && plantMatrix[i, j] != null)
		{
            i = Random.Range(0, 5);
            sat += 1;

            j = sat / 6;
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

        PlaceHolder placeholder = placeholdersMatrix[linePos * 12 + columnPos].GetComponent<PlaceHolder>();

        if (!placeholder.canBuild)
		{
            // Can't build !
            return false;
		}

        placeholder.canBuild = false;

        Transform pos = placeholdersMatrix[linePos*12+columnPos].transform;

        GameObject instance = Instantiate(plantTypes[plant], pos.position, Quaternion.identity);
        instance.GetComponent<BasicPlantBehaviour>().Initialize(this, zombieManager, linePos, columnPos, sunMultiplier);
        plantMatrix[linePos, columnPos] = instance;

        totalSun -= priceGrid[plant];

        return true;
    }

    public void FreePlantPlaceHolder(int linePos, int columnPos)
	{
        placeholdersMatrix[linePos * 12 + columnPos].GetComponent<PlaceHolder>().canBuild = true;
        plantMatrix[linePos, columnPos] = null;
    }
}
