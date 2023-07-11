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
    [SerializeField] private float blinkDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GameObject eated;
    private float startTime;
    private bool isEating;
    private float blinkTimer;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(Mathf.Sin((Time.time - startTime) * frequency), -0.8f, 1f) * amplitude));

        if (!isEating)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-1, 0, 0) * Mathf.Clamp01(0.8f - (Mathf.Abs(Mathf.Sin((Time.time - startTime) * frequency) + 1) / 2)), speed * Time.deltaTime);
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
        StartCoroutine(Blink());

    }

    public enum ZombieColor
    {
        Neutral,
        Blue,
        Red
    }
    private IEnumerator Blink()
    {
        blinkTimer = 0;
        while (blinkTimer < blinkDuration)
        {
            // Interpolation linéaire entre la couleur d'origine et la couleur de clignotement
            float t = Mathf.PingPong(blinkTimer * 1f, 1f) / blinkDuration;
            spriteRenderer.color = Color.Lerp(Color.green, Color.white, t);

            blinkTimer += Time.deltaTime;
            yield return null;
        }

    }
}
