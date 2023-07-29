using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1 : MonoBehaviour
{
    [SerializeField] private GameObject click;
    [SerializeField] private GameObject pressF;
    [SerializeField] private BuyHolder tombstone;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private float appearTime;
    [SerializeField] private float timeBetweenText;

    private float appearTimer;

    private void OnEnable()
    {
        StartCoroutine(TutorialRoutine());
    }
    private IEnumerator TutorialRoutine()
    {
        text1.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text1.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        click.SetActive(false);
        text1.enabled = false;

        text2.enabled = true;
        appearTimer = 0;

        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text2.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        pressF.SetActive(true);
        while (!Input.GetKey(KeyCode.F) && !tombstone.GetSelect())
        {
            yield return null;
        }
        text2.enabled = false;
        pressF.SetActive(false);
        yield return new WaitForSeconds(timeBetweenText);

        text3.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text3.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        click.SetActive(false);
        text3.enabled = false;
        gameObject.SetActive(false);
    }
}
