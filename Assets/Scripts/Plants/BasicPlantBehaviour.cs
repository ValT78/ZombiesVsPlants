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


    public enum Colors
	{
        Neutral,
        Blue,
        Red
	}


    public static GameObject InstantiatePlant(GameObject prefab, int linePos, int colomunPos)
	{
        GameObject instance = Instantiate(prefab, new Vector3(colomunPos, linePos, 0), Quaternion.identity);
        return instance;
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
            // Call function GetBrain() from zombieManager
            return true;
        }

        return false;
    }

}
