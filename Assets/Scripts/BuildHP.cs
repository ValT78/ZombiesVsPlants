using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHP : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float blinkDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [HideInInspector] public int distance = 12;

    [HideInInspector] public GameObject placeHolder;
    public int color;
    private ZombieManager zombieManager;
    private float blinkTimer;

    private void Start()
    {
        zombieManager = FindObjectOfType<ZombieManager>();

    }
    public void TakeDamage(float damage)
    {
        print(damage / (distance - 1));
        HP -= damage/(distance-1);
        if (HP<=0f)
        {
            zombieManager.RemoveBuild(this.gameObject, placeHolder, color);
            Destroy(this.gameObject);
        }
        StartCoroutine(Blink());
    }
    private IEnumerator Blink()
    {
        blinkTimer = 0;
        while (blinkTimer < blinkDuration)
        {
            float t = Mathf.PingPong(blinkTimer * 1f, 1f) / blinkDuration;
            spriteRenderer.color = Color.Lerp(Color.red, Color.white, t);

            blinkTimer += Time.deltaTime;
            yield return null;
        }
        
    }

}
