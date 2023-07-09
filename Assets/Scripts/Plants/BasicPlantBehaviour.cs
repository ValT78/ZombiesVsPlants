using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlantBehaviour : MonoBehaviour
{
    [Tooltip("The plant's name displayed to the player")]
    public PlantTypes plantType;
    [Tooltip("Amount of sunflowers requiered to plant it")]
    public int cost;
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

    [SerializeField] private PlantManager plantManager;
    [SerializeField] private ZombieManager zombieManager;

    private int[] plantPosition = new int[2];

    private bool initialized = false;



    private int framesCount = 1;
    private int framesPerBullet;


    private int nextWait = 720;


    public enum PlantTypes
    {
        Sunflower,
        Supersunflower,
        Wallnut,
        Brain,
        Peashooter,
        DoublePeashooter
        
    }

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

	void Start()
	{
        currentHP = HP;
        framesPerBullet = (int)(60 / attackSpeed);
	}

	void Update()
    {

        if (plantType >= PlantTypes.Peashooter && framesCount % framesPerBullet == 0)
            ShootProjectile();


        if (plantType == PlantTypes.DoublePeashooter && framesCount % framesPerBullet == framesPerBullet/6)
            ShootProjectile();


        if(plantType <= PlantTypes.Supersunflower && framesCount % nextWait == 0)
		{
            plantManager.GetSun(50);

            if (plantType == PlantTypes.Supersunflower)
                plantManager.GetSun(50);

            nextWait = Random.Range(720, 2000);

		}

        framesCount ++;
    }


    private void ShootProjectile()
	{
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<ProjectileBehaviour>().Initialize(bulletSpeed, bulletDamage); // May be very VERY glutton
	}



    public void takeDamage(int damage) // Decreases the plant's hp and grants brains if that kills it
	{
        currentHP -= damage;
		if (currentHP <= 0)
		{
            zombieManager.ObtainBrains(brainReward);
            if(plantType == PlantTypes.Brain)
            {
                zombieManager.goldenBrains.Remove(this.gameObject);
                zombieManager.CheckVictory();
            }
            Death();
        }
    }

    public void Death()
	{
        Destroy(gameObject);
        plantManager.FreePlantPlaceHolder(plantPosition[0], plantPosition[1]);
	}
}
