using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

	public BulletColor bulletColour;


	private const int bulletLifeTime = 480;

    private float bulletSpeed;
	private int damage;

	private int frameCount = 0;

	private bool initialized = false;

    public void Initialize(float bs, int dmg)
	{
		bulletSpeed = bs + Random.Range(-0.3f,0.3f);
		damage = dmg;
		initialized = true;
	}
    
	public enum BulletColor
	{
		Neutral,
		Blue,
		Red
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

		if (initialized && collider.CompareTag("Nexus"))
		{
			//Debug.Log("Dealt damage !");
			collider.GetComponent<NexusManager>().TakeDamage(damage);
			Destroy(gameObject);
		}
		else if(initialized && collider.CompareTag("Build"))
		{
			collider.GetComponent<BuildHP>().TakeDamage(damage);
			Destroy(gameObject);
		}
		else if(initialized && collider.CompareTag("Zombie"))
		{
			collider.GetComponent<ZombieBehaviour>().TakeDamage(damage);
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
