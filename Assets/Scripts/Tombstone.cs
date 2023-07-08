using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour
{
    [SerializeField] private GameObject shinyBrainPrefab;

    [SerializeField] private float timeGenerateBrains;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateBrains());
    }

    // Update is called once per frame
    
    private IEnumerator GenerateBrains()
    {
        yield return new WaitForSeconds(timeGenerateBrains);
        SummonBrain();
        StartCoroutine(GenerateBrains());

    }

   

    private void SummonBrain()
    {
        Instantiate(shinyBrainPrefab, transform.position, Quaternion.identity);
    }
}
