using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusManager : MonoBehaviour
{

    public int startingHP;

    public GameObject lifeBar;



    private int currentHP;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage(int dmg)
	{
        currentHP -= dmg;
        if (currentHP <= 0)
            Death();
	}

    private void Death()
	{

	}

}
