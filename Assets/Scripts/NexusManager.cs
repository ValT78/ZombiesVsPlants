using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexusManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverScreen;

    private int startingHP;

    [SerializeField] private Image lifeBar;
    [SerializeField] private RectTransform lifeBarRect;
    [SerializeField] private Image redBar;
    [SerializeField] private RectTransform redBarRect;
    [SerializeField] private float resetRecentDamage;
    [SerializeField] private float goBackTime;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeAmount;

    private int currentHP;
    private float recentDamage;
    private float timer;
    private Vector3 initialPosition;

    private void Awake()
    {
        startingHP = Transporter.nexusLife;
        currentHP = startingHP;
    }
    void Start()
    {
        redBarRect.position = new Vector2(redBarRect.position.x, lifeBarRect.position.y+ lifeBarRect.localScale.y/2);
        recentDamage = 0;
        initialPosition = transform.position;
    }


    public void TakeDamage(int dmg)
	{
        currentHP -= dmg;
        if (currentHP <= 0)
            Death();

        float percentage = (float)currentHP / (float)startingHP;
        lifeBar.fillAmount = percentage;
        redBar.enabled = true;
        recentDamage += dmg;
        redBarRect.position = new Vector2(redBarRect.position.x, lifeBarRect.position.y +lifeBarRect.localScale.y * percentage / 2);
        redBar.fillAmount = recentDamage / startingHP;
        timer = 0;
        StartCoroutine(ResetRecentDamage());
        StartCoroutine(Movement());
    }
    private IEnumerator ResetRecentDamage()
    {
        float startDamage = currentHP;

        while(startDamage == currentHP && timer < resetRecentDamage)
        {
            timer += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        float startFill = redBar.fillAmount;
        float startingDamage = recentDamage;
        float t = 0;
        while(startDamage == currentHP && t<goBackTime)
        {
            t += 0.05f;
            redBar.fillAmount = Mathf.Clamp01(Mathf.Lerp(startFill, 0, t/goBackTime));
            recentDamage = Mathf.Clamp01(Mathf.Lerp(startingDamage, 0, t/goBackTime));
            yield return new WaitForSeconds(0.05f);
        }
        if (startDamage == currentHP)
        {
            redBar.enabled = false;
        }
    }
    private IEnumerator Movement()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;

            transform.position = initialPosition + randomOffset;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = initialPosition;
    }

    private void Death()
	{
        Instantiate(gameOverScreen,Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
	}

}
