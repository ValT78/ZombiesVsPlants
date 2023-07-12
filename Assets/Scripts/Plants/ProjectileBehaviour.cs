using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

	[SerializeField] private int bulletColor;


	private const int bulletLifeTime = 480;

    private float bulletSpeed;
	private int damage;

	private int frameCount = 0;

	private bool initialized = false;

    public void Initialize(float bs, int dmg, int plantColor)
	{
		bulletSpeed = bs + Random.Range(-0.3f,0.3f);
		damage = dmg;
		initialized = true;
		bulletColor = plantColor;
	}

    void FixedUpdate()
    {
		if (frameCount > bulletLifeTime)
			Destroy(gameObject);

		if(initialized)
			transform.Translate(bulletSpeed / 60, 0, 0);

		frameCount++;
    }

	private void OnTriggerEnter2D(Collider2D collider)
	{

		//Debug.Log("Collision !");

		if (initialized && collider.TryGetComponent<NexusManager>(out NexusManager nexusManager))
		{
			//Debug.Log("Dealt damage !");
			nexusManager.TakeDamage(damage);
			Destroy(gameObject);
		}
		else if(initialized && collider.TryGetComponent<BuildHP>(out BuildHP build))
		{
			build.TakeDamage(damage);
			Destroy(gameObject);
		}
		else if(initialized && collider.TryGetComponent<ZombieBehaviour>(out ZombieBehaviour zombie))
		{
			zombie.TakeDamage(damage, bulletColor);
			Destroy(gameObject);

		}
	}
	// Deal damage to the zombie or building
			// collision.collider.GetComponent<ZombieManager>().
/*
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (initialized && collision.collider.CompareTag("Zombie"))
		{
			// Deal damage to the zombie or building
			// collision.collider.GetComponent<ZombieManager>().
			Destroy(gameObject);
		}
	}*/
}
