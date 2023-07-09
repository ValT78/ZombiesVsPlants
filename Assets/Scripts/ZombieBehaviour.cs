using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float frequency;
    [SerializeField] private float amplitude;
    [SerializeField] private int damage;
    [SerializeField] private int HP;
    [SerializeField] private ZombieColor zombieColor; 

    private GameObject eated;
    private float startTime;
    private bool isEating;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float rotation = Mathf.Sin((Time.time - startTime) * frequency);
        rotation = Mathf.Clamp(rotation, -0.8f, 1f) * amplitude;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));

        if (!isEating)
        {
            float offset = Mathf.Clamp01(0.8f - (Mathf.Abs(Mathf.Sin((Time.time - startTime) * frequency) + 1) / 2));
            Vector3 destination = transform.position + new Vector3(-1, 0, 0) * offset;
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Plant"))
        {
            if(!isEating)
            {
                StartCoroutine(Eat());
            }
            isEating = true;
            eated = collider.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Plant"))
        {
            isEating = false;
        }
    }
    private IEnumerator Eat()
    {
        yield return new WaitForSeconds(0.2f);
        while (isEating)
        {
            eated.GetComponent<BasicPlantBehaviour>().takeDamage(damage);
            yield return new WaitForSeconds(12.5f/frequency);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public enum ZombieColor
    {
        Neutral,
        Blue,
        Red
    }

}
