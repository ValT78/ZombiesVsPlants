using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField] private GameObject shinyBrainPrefab;

    [SerializeField] private int startBrains;
    [SerializeField] private float timePassiveBrains;

    public List<Transform> availableSpawn;
    private int brains;
    void Start()
    {
        brains = startBrains;
        StartCoroutine(PassiveBrains());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PassiveBrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(timePassiveBrains);
            SummonGroundBrain();
        }

    }

    public void ObtainBrains(int brains)
    {
        this.brains += brains;
    }
    public int GetBrains()
    {
        return brains;
    }
    private void SummonGroundBrain()
    {
        GameObject shinyBrain = Instantiate(shinyBrainPrefab, new Vector2(Random.Range(-15, 15), -10f), Quaternion.identity);
        shinyBrain.GetComponent<BrainItem>().SetFromGround(true);
    }
}
