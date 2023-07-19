using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

	[SerializeField] private int bulletColor;
    private float bulletSpeed;
	private int damage;
	private bool initialized = false;
	private bool hasCollided = false;

	public void Initialize(float bs, int dmg, int plantColor)
	{
		bulletSpeed = bs + Random.Range(-0.3f,0.3f);
		damage = dmg;
		initialized = true;
		bulletColor = plantColor;
	}

    void FixedUpdate()
    {

		if(initialized)
			transform.Translate(bulletSpeed / 60, 0, 0);

    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if(!hasCollided)
        {
			if (initialized && collider.TryGetComponent<NexusManager>(out NexusManager nexusManager))
			{
				hasCollided = true;
				nexusManager.TakeDamage(damage);
				Destroy(gameObject);
			}
			else if (initialized && collider.TryGetComponent<BuildHP>(out BuildHP build))
			{
				hasCollided = true;
				build.TakeDamage(damage);
				Destroy(gameObject);
			}
			else if (initialized && collider.TryGetComponent<ZombieBehaviour>(out ZombieBehaviour zombie))
			{
				hasCollided = true;
				zombie.TakeDamage(damage, bulletColor);
				Destroy(gameObject);

			}
		}
		
	}
	
}
