using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusManager : MonoBehaviour
{

    public int startingHP;

    public GameObject lifeBar;

    public const float baseScaleY = 31.95916f;

    private int currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = startingHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int dmg)
	{
        lifeBar.transform.localScale += new Vector3(0, -baseScaleY*dmg/startingHP, 0);

        currentHP -= dmg;
        if (currentHP <= 0)
            Death();
	}

    private void Death()
	{
        Destroy(gameObject);
	}

}
