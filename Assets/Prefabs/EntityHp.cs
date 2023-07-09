using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHp : MonoBehaviour
{
    [SerializeField] private int HP;
    // Start is called before the first frame update
    
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP<=0)
        {
            Destroy(this.gameObject);
        }
    }

}
