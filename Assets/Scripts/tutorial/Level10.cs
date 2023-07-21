using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level10 : MonoBehaviour
{
    [SerializeField] private BuyHolder tombstone;

    [SerializeField] private GameObject click;
    [SerializeField] private GameObject arrow;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    [SerializeField] private TextMeshProUGUI text5;
    [SerializeField] private TextMeshProUGUI text6;
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
        arrow.GetComponent<Arrow>().SetPos(new(-10.5f, 6.33f, 0), new(-10.5f, 3.76f, 0));
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text1.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        while (tombstone.tabColor == 0)
        {
            yield return null;
        }
        arrow.SetActive(false);
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
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        text2.enabled = false;
        click.SetActive(false);

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
        text3.enabled = false;
        click.SetActive(false);

        text4.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text4.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        text4.enabled = false;
        click.SetActive(false);

        text5.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text5.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        click.SetActive(false);
        text5.enabled = false;

        arrow.SetActive(true);
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(-1.4f, 6.33f, 0), new(-1.4f, 3.76f, 0));
        text6.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text6.alpha = appearTimer / appearTime;
            yield return null;

        }
        while (!tombstone.GetSelect() || tombstone.tabColor == 0)
        {
            yield return null;
        }
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(10.55f, 0, 0), new(7, 0, 0));

        while (ZombieManager.builds.Count < 1)
        {
            yield return null;
        }
        arrow.SetActive(false);
        yield return new WaitForSeconds(timeBetweenText);
        text6.enabled = false;

        gameObject.SetActive(false);

    }
}
