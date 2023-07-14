using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlantBehaviour : MonoBehaviour
{
    [Tooltip("The plant's name displayed to the player")]
    public PlantTypes plantType;
    [Tooltip("The plant's Health Points")]
    public int HP;
    [Tooltip("Bullets per seconds")]
    public float attackSpeed;
    [Tooltip("In units per second")]
    public float bulletSpeed;
    [Tooltip("In units per second")]
    public int bulletDamage;
    [Tooltip("In units per second")]
    public int plantColor;
    [Tooltip("Brains granted to player uppon death of the plant")]
    public int brainReward;


    [Tooltip("The projectile used by the plant")]
    public GameObject bulletPrefab;

    [SerializeField] private float blinkDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;


    private int currentHP;

    [SerializeField] private PlantManager plantManager;
    [SerializeField] private ZombieManager zombieManager;

    private int[] plantPosition = new int[2];

    private bool initialized = false;
    private float blinkTimer;
    private float sunMultiplier;



    private bool pearTrigger = false;

    public enum PlantTypes
    {
        Sunflower,
        Supersunflower,
        Wallnut,
        Brain,
        pear,
        Peashooter,
        DoublePeashooter,
        TriplePea
        
    }

    

    public void Initialize(PlantManager p, ZombieManager z, int linePos, int columnPos, float sunMultiplier)
	{
        plantManager = p;
        zombieManager = z;
        plantPosition[0] = linePos;
        plantPosition[1] = columnPos;
        initialized = true;
        this.sunMultiplier = sunMultiplier;
    }

	void Start()
	{
        currentHP = HP;
        if (plantType <= PlantTypes.Supersunflower)
        {
            StartCoroutine(SunFlower());
        }
        if (plantType >= PlantTypes.Peashooter)
        {
            StartCoroutine(Peashooter());

        }


    }

    private IEnumerator SunFlower()
    {
        while (true)
        {
            yield return new WaitForSeconds(12f/sunMultiplier);
            plantManager.GetSun(25);
            if (plantType == PlantTypes.Supersunflower)
            {
                plantManager.GetSun(25);
            }
            yield return new WaitForSeconds(12f / sunMultiplier);

        }
    }
    private IEnumerator Peashooter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/attackSpeed-0.1f);
            ShootProjectile(0);
            if (plantType == PlantTypes.TriplePea)
            {
                ShootProjectile(2.6f);
                ShootProjectile(-2.6f);

            }
            yield return new WaitForSeconds(0.1f);
            if (plantType == PlantTypes.DoublePeashooter)
                ShootProjectile(0);
        }
    }

    private void ShootProjectile(float y)
	{
        GameObject bullet = Instantiate(bulletPrefab, transform.position+new Vector3(0,y,0), Quaternion.identity);
        bullet.GetComponent<ProjectileBehaviour>().Initialize(bulletSpeed, bulletDamage, plantColor); // May be very VERY glutton
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
        StartCoroutine(Blink());
    }

    public void Death()
	{
        Destroy(gameObject);
        plantManager.FreePlantPlaceHolder(plantPosition[0], plantPosition[1]);
	}
    private IEnumerator Blink()
    {
        blinkTimer = 0;
        while (blinkTimer < blinkDuration)
        {
            // Interpolation linéaire entre la couleur d'origine et la couleur de clignotement
            float t = Mathf.PingPong(blinkTimer * 1f, 1f) / blinkDuration;
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, t);

            blinkTimer += Time.deltaTime;
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(plantType== PlantTypes.pear && !pearTrigger)
        {
            if(collision.gameObject.CompareTag("Zombie")) {
                pearTrigger = true;
                StartCoroutine(Pear(collision.transform.position));
            }
        }
    }
    private IEnumerator Pear(Vector3 finalPosition)
    {
        Vector3 initialPosition = transform.position;
        float t = 0;
        while (t < 0.2) {
            transform.position = Vector3.Lerp(initialPosition, finalPosition + new Vector3(0, 2.6f, 0), t/0.2f);
            t += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.3f);

        initialPosition = transform.position;
        t = 0;
        while (t < 0.1)
        {
            transform.position = Vector3.Lerp(initialPosition, finalPosition + new Vector3(0, -2f, 0), t / 0.1f);
            t += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Zombie"))
            {
                Destroy(collider.gameObject);
                // Faites quelque chose avec le GameObject Zombie détecté
            }
        }
        Destroy(gameObject, 0.3f);

    }
}
