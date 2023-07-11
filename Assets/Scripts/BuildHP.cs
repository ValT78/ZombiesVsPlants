using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHP : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float blinkDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [HideInInspector] public int distance = 12;

    private float blinkTimer;

    public void TakeDamage(int damage)
    {
        HP -= damage*2f/(distance-1);
        if (HP<=0f)
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(Blink());
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
