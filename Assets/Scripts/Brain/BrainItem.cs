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
    [SerializeField] private float floatRange;
    [SerializeField] private float floatSpeed;
    [SerializeField] private float floatTime;

    private bool fromGround;
    private float collectTimer = 0;
    private bool getClicked = false;
    private Vector3 startPosition;
    private Vector2 newPosition;
    private float fromGroundSpeed;

    void Start()
    {
        StartCoroutine(Depop());
        StartCoroutine(FloatingAnimation());

        zombieManager = FindObjectOfType<ZombieManager>();
        target = GameObject.Find("brainUI").transform.position;
        fromGroundSpeed = Random.Range(1.0f, 2.0f);
        startPosition = transform.position;
        newPosition = transform.position + new Vector3(0.1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (fromGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + fromGroundSpeed * Time.deltaTime, transform.position.z);
        }
        else if(!getClicked)
        {
            transform.position = Vector2.Lerp(transform.position, newPosition, floatSpeed * Time.deltaTime);
        }

        if (getClicked)
        {
            collectTimer += Time.deltaTime;

            float t = Mathf.Clamp01(collectTimer / collectTime);

            transform.position = Vector3.Lerp(startPosition, target, t);

            if (t >= 1f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!getClicked)
        {
            zombieManager.GetComponent<ZombieManager>().ObtainBrains(storedBrains);
        }
        getClicked = true;
        startPosition = transform.position;

    }
    private void OnMouseOver()
    {
        print("check");
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
    private IEnumerator FloatingAnimation()
    {
        while (!fromGround && !getClicked)
        {
            Vector2 randomDirection = Random.insideUnitCircle;
            newPosition = new Vector2(startPosition.x, startPosition.y) + randomDirection * floatRange;
            yield return new WaitForSeconds(floatTime);
            
        }
    }
}
