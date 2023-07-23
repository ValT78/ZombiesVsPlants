using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHP : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float blinkDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject shinyBrainPrefab;
    [SerializeField] private float timeGenerateBrains;


    [HideInInspector] public int distance = 12;

    [HideInInspector] public GameObject placeHolder;
    public int color;
    private float blinkTimer;
    private Color baseColor;
    private float brainMultiplier;

    private void Start()
    {
        baseColor = spriteRenderer.color;
        brainMultiplier = Transporter.brainMultiplier;
        StartCoroutine(GenerateBrains());
    }
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP<=0f)
        {
            ZombieManager.zombieManager.RemoveBuild(this.gameObject, placeHolder, color);
            Destroy(this.gameObject);
        }
        StartCoroutine(Blink(Color.red, 1 + Time.time));
    }
    private IEnumerator Blink(Color color, float blinkDuration)
    {
        blinkTimer = Time.time;
        while (blinkTimer < blinkDuration)
        {
            float t = (Mathf.Sin((blinkDuration-blinkTimer)*4*Mathf.PI)+1)/2;
            spriteRenderer.color = Color.Lerp(baseColor, color, t);

            blinkTimer += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = baseColor;

    }
    private IEnumerator GenerateBrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeGenerateBrains / brainMultiplier-1f);
            StartCoroutine(Blink(Color.magenta, 2+Time.time));
            yield return new WaitForSeconds(1f);
            SummonBrain();
        }
    }

    private void SummonBrain()
    {
        Instantiate(shinyBrainPrefab, transform.position, Quaternion.identity);
    }
}
