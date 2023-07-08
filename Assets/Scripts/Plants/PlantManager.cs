using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

    public GameObject[] plantTypes; // All prefabs

    private GameObject[,] plantMatrix = new GameObject[5, 12];

    public ZombieManager zombieManager;


    void Start()
    {
        for(int i = 0; i < 5; i++)
		{
            for(int j = 0; j < 12; j++)
			{
                InstantiatePlant(0, i, j);
            }
		}
    }

    void Update()
    {
        
    }

    public void InstantiatePlant(int plant, int linePos, int columnPos)
    {
        if(plantMatrix[linePos,columnPos] != null)
		{
            Debug.LogError("Can't spawn a plant on top of an existing plant !");
            return;
		}
        GameObject instance = Instantiate(plantTypes[plant], new Vector3(columnPos, linePos, 0), Quaternion.identity);
        instance.GetComponent<BasicPlantBehaviour>().Initialize(this, zombieManager, linePos, columnPos);
        plantMatrix[linePos, columnPos] = instance;
    }

    public void FreePlantPlaceHolder(int linePos, int columnPos)
	{
        plantMatrix[linePos, columnPos] = null;
    }
}
