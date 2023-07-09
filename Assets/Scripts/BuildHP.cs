using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHP : MonoBehaviour
{
    [SerializeField] private float HP;

    [HideInInspector] public int distance = 12;

    public void TakeDamage(int damage)
    {
        HP -= damage*2f/(distance-1);
        if(HP<=0f)
        {
            Destroy(this.gameObject);
        }
    }

}
