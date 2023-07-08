using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainItem : MonoBehaviour
{
    private ZombieManager zombieManager;
    private Vector3 target;

    [SerializeField] private int storedBrains;
    [SerializeField] private float despawnTime;
    [SerializeField] private float collectTime;
    [SerializeField] private float fromGroundSpeed;

    private bool fromGround;
    private float collectTimer = 0;
    private bool getClicked = false;
    private Vector3 startPosition;

    void Start()
    {
        StartCoroutine(Depop());
        zombieManager = FindObjectOfType<ZombieManager>();
        target = GameObject.Find("brainUI").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (fromGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + fromGroundSpeed * Time.deltaTime, transform.position.z);
        }
        if(getClicked)
        {
            collectTimer += Time.deltaTime;

            float t = Mathf.Clamp01(collectTimer / collectTime);

            transform.position = Vector3.Lerp(startPosition, target, t);

            if (t >= 1f)
            {
                zombieManager.GetComponent<ZombieManager>().GetBrains(storedBrains);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            getClicked = true;
            startPosition = transform.position;
        }
    }
    private IEnumerator Depop()
    {
        yield return new WaitForSeconds(despawnTime);
        if (!getClicked)
        {
            Destroy(gameObject);
        }
    }

    public void SetFromGround(bool ground)
    {
        fromGround = ground;
    }
}
