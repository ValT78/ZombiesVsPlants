using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHP : MonoBehaviour
{
    [SerializeField] private float HP;

    [HideInInspector] public int distance;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {
        HP -= damage*2f/(distance-1);
        if(HP<=0f)
        {
            Destroy(this.gameObject);
        }
    }

}
