using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

	private const int bulletLifeTime = 480;

    private float bulletSpeed;
	private int damage;

	private int frameCount = 0;

	private bool initialized = false;

    public void Initialize(float bs, int dmg)
	{
		bulletSpeed = bs + Random.Range(-0.4f,0.4f);
		damage = dmg;
		initialized = true;
	}
    

    void FixedUpdate()
    {
		if (frameCount > bulletLifeTime)
			Destroy(gameObject);

		if(initialized)
			transform.Translate(bulletSpeed / 60, 0, 0);

		frameCount++;
    }

	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		if (initialized && collision.collider.CompareTag("Zombie"))
		{
			// Deal damage to the zombie or building
			// collision.collider.GetComponent<ZombieManager>().
			Destroy(gameObject);
		}
	}

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
