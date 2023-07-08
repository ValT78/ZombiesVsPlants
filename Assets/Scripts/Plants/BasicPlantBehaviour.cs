using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlantBehaviour : MonoBehaviour
{
    [Tooltip("The plant's name displayed to the player")]
    public string plantName;
    [Tooltip("The plant's Health Points")]
    public int HP;
    [Tooltip("Bullets every 5 seconds")]
    public float attackSpeed;
    [Tooltip("In units per second")]
    public float bulletSpeed;
    [Tooltip("In units per second")]
    public int bulletDamage;
    [Tooltip("In units per second")]
    public Colors plantColor;
    [Tooltip("Brains granted to player uppon death of the plant")]
    public int brainReward;


    private int currentHP;

    private PlantManager plantManager;
    private ZombieManager zombieManager;
    private int[] position = new int[2];

    private bool initialized = false;

    public enum Colors
	{
        Neutral,
        Blue,
        Red
	}


    

    public void Initialize(PlantManager p, ZombieManager z, int linePos, int columnPos)
	{
        plantManager = p;
        zombieManager = z;
        position[0] = linePos;
        position[1] = columnPos;
        initialized = true;
    }

	private void Start()
	{
        currentHP = HP;
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    bool zombieInLine(int i) // Returns true if at least one zombie is on the line
	{
        return true;
	}


    public bool takeDamage(int damage) // Decreases the plant's hp and returns true if that kills it
	{
        currentHP -= damage;

		if (currentHP <= 0)
		{
            zombieManager.GetBrains(brainReward);
            Death();
            return true;
        }
        return false;
    }

    public void Death()
	{
        plantManager.FreePlantPlaceHolder(position[0], position[1]);
        Destroy(gameObject);
	}
}
