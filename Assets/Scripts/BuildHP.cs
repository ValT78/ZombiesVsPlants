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

    private void Start()
    {
        baseColor = spriteRenderer.color;
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
        StartCoroutine(Blink(Color.red, 0.8f));
    }
    private IEnumerator Blink(Color color, float blinkDuration)
    {
        blinkTimer = 0;
        while (blinkTimer < blinkDuration)
        {
            float t = Mathf.PingPong(blinkTimer * 3f, blinkDuration) / blinkDuration;
            spriteRenderer.color = Color.Lerp(color, baseColor, t);

            blinkTimer += Time.deltaTime;
            yield return null;
        }
        
    }
    private IEnumerator GenerateBrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeGenerateBrains / (Transporter.sunMultiplier/1.5f)-1f);
            StartCoroutine(Blink(Color.magenta, 1.5f));
            yield return new WaitForSeconds(1f);
            SummonBrain();
        }
    }

    private void SummonBrain()
    {
        Instantiate(shinyBrainPrefab, transform.position, Quaternion.identity);
    }
}
