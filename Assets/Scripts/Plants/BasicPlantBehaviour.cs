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

    [SerializeField] private SpriteRenderer spriteRenderer;


    private int currentHP;

    [SerializeField] private GameObject brain;

    private PlaceHolder plantPosition;
    private Color baseColor;

    private float blinkTimer;



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

    

    public void Initialize(PlaceHolder position)
	{
        plantPosition = position;
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
        baseColor = spriteRenderer.color;

    }

    private IEnumerator SunFlower()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f/ Transporter.sunMultiplier-1f);
            StartCoroutine(Blink(Color.green, 1.5f));
            yield return new WaitForSeconds(1f);
            PlantManager.plantManager.GetSun(25);
            if (plantType == PlantTypes.Supersunflower)
            {
                PlantManager.plantManager.GetSun(25);
            }
            yield return new WaitForSeconds(10f / Transporter.sunMultiplier);

        }
    }
    private IEnumerator Peashooter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/attackSpeed-0.3f);
            ShootProjectile(0);
            if (plantType == PlantTypes.TriplePea)
            {
                if(transform.position.y<5)
                    ShootProjectile(2.6f);
                if(transform.position.y>-5)
                    ShootProjectile(-2.6f);

            }
            yield return new WaitForSeconds(0.3f);
            if (plantType == PlantTypes.DoublePeashooter)
                ShootProjectile(0);
        }
    }

    private void ShootProjectile(float y)
	{
        GameObject bullet = Instantiate(bulletPrefab, transform.position+new Vector3(-2,y,0), Quaternion.identity);
        bullet.GetComponent<ProjectileBehaviour>().Initialize(bulletSpeed, bulletDamage, plantColor); // May be very VERY glutton
	}



    public void TakeDamage(int damage) // Decreases the plant's hp and grants brains if that kills it
	{
        currentHP -= damage;
		if (currentHP <= 0)
		{
            while(brainReward>0)
            {
                float randomAngle = Random.Range(0f, 2f * Mathf.PI);
                float randomRadius = Random.Range(0f, 1f);
                Instantiate(brain, new Vector3(transform.position.x + randomRadius * Mathf.Cos(randomAngle), transform.position.y + randomRadius * Mathf.Sin(randomAngle), transform.position.z), Quaternion.identity);
                brainReward -= 25;
            }
            if(plantType == PlantTypes.Brain)
            {
                ZombieManager.zombieManager.goldenBrains.Remove(gameObject);
                ZombieManager.zombieManager.CheckVictory();
            }
            Death();
        }
        StartCoroutine(Blink(Color.red, 0.8f));
    }

    public void Death()
	{
        if (plantType != PlantTypes.Brain)
        {
            plantPosition.canBuild = true;
        }
        Destroy(gameObject);
	}
    private IEnumerator Blink(Color color, float blinkDuration)
    {
        blinkTimer = 0;
        while (blinkTimer < blinkDuration)
        {
            // Interpolation linéaire entre la couleur d'origine et la couleur de clignotement
            float t = Mathf.PingPong(blinkTimer * 3f, blinkDuration) / blinkDuration;
            spriteRenderer.color = Color.Lerp(color, baseColor, t);

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
                plantPosition.canBuild = true;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, 1f, 0), 3f);

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
