using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private int bulletColor;
	[SerializeField] private bool isSpores;

	private List<ZombieBehaviour> touched = new();

	private int damage;
	private bool hasCollided = false;

	public void Initialize(int dmg, float vx, float vy)
	{
		rb.AddForce(new(vx, vy), ForceMode2D.Impulse);
		damage = dmg;
		Destroy(gameObject, 8f);
	}

    private void DealDamage()
    {
		ZombieBehaviour zombie = touched[0];
		int HP = 0;
		foreach (ZombieBehaviour touch in touched)
		{
			if(HP<touch.HP)
            {
				zombie = touch;
				HP = touch.HP;
			}
			else if(HP==touch.HP && zombie.currentHP>touch.currentHP)
			{
				zombie = touch;
			}
		}
		zombie.TakeDamage(damage, bulletColor);
		Destroy(gameObject);
	}


    private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<NexusManager>(out NexusManager nexusManager))
		{
			if (!hasCollided)
				nexusManager.TakeDamage(damage);
			Destroy(gameObject);
		}
		else if (collider.TryGetComponent<BuildHP>(out BuildHP build))
		{
			build.TakeDamage(damage);
			Destroy(gameObject);
		}
		else if (collider.TryGetComponent<ZombieBehaviour>(out ZombieBehaviour zombie))
		{
			hasCollided = true;
			if (isSpores)
            {
				zombie.TakeDamage(damage, bulletColor);
				Destroy(gameObject, 5f);
				rb.AddForce(new(-rb.velocity.x*3/4,0), ForceMode2D.Impulse);
				if (rb.velocity.x < 0)
				{
					Destroy(gameObject);
				}
			}
			else
            {
				touched.Add(zombie);
				Invoke("DealDamage",0.1f);
			}

		}
		
	}
	
}
