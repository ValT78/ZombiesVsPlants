using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlantBehaviour : MonoBehaviour
{
    [Tooltip("The plant's name displayed to the player")]
    public string plantName;
    [Tooltip("The plant's Health Points")]
    public int HP;
    [Tooltip("Bullets per seconds")]
    public float attackSpeed;
    [Tooltip("In units per second")]
    public float bulletSpeed;
    [Tooltip("In units per second")]
    public int bulletDamage;
    [Tooltip("In units per second")]
    public Colors plantColor;
    [Tooltip("Brains granted to player uppon death of the plant")]
    public int brainReward;


    [Tooltip("The projectile used by the plant")]
    public GameObject bulletPrefab;



    private int currentHP;

    private PlantManager plantManager;
    private ZombieManager zombieManager;

    private int[] plantPosition = new int[2];

    private bool initialized = false;



    private int framesCount;
    private int framesPerBullet;



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
        plantPosition[0] = linePos;
        plantPosition[1] = columnPos;
        initialized = true;
    }

	private void Start()
	{
        currentHP = HP;
        framesPerBullet = (int)(60/attackSpeed);
	}

	// Update is called once per frame
	void Update()
    {
        if (framesPerBullet!=0 && framesCount % framesPerBullet == 0 && zombieInLine(plantPosition[0]))
            ShootProjectile();

        framesCount ++;
    }


    private void ShootProjectile()
	{
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<ProjectileBehaviour>().Initialize(bulletSpeed, bulletDamage); // May be very VERY glutton
	}


    private bool zombieInLine(int i) // Returns true if at least one zombie is on the line
	{
        // Look at the zombie list row i to see if it's empty or not (in zombie manager)
        return true;
	}


    public void takeDamage(int damage) // Decreases the plant's hp and grants brains if that kills it
	{
        currentHP -= damage;

		if (currentHP <= 0)
		{
            zombieManager.ObtainBrains(brainReward);
            Death();
        }
    }

    public void Death()
	{
        plantManager.FreePlantPlaceHolder(plantPosition[0], plantPosition[1]);
        Destroy(gameObject);
	}
}
