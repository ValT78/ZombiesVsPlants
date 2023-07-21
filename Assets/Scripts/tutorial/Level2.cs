using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2 : MonoBehaviour
{
    [SerializeField] private GameObject click;
    [SerializeField] private GameObject arrow;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
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
        arrow.SetActive(true);
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(7, 6.33f, 0), new(7, 3.76f, 0));
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
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, 90));
        arrow.GetComponent<Arrow>().SetPos(new(0, -4, 0), new(0, 0, 0));
        appearTimer = 0;

        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text2.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        text2.enabled = false;
        click.SetActive(false);
        arrow.SetActive(false);
        gameObject.SetActive(false);


    }
}
