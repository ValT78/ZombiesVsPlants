using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject click;
    [SerializeField] private GameObject arrowPosition;
    [SerializeField] private GameObject arrow;
    [SerializeField] private BuyHolder zombie;
    [SerializeField] private BuyHolder tombstone;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    [SerializeField] private TextMeshProUGUI text5;
    [SerializeField] private TextMeshProUGUI text6;
    [SerializeField] private TextMeshProUGUI text7;
    [SerializeField] private TextMeshProUGUI text8;
    [SerializeField] private float appearTime;
    [SerializeField] private float timeBetweenText;

    private float appearTimer;
    
    
    private void OnEnable()
    {
        StartCoroutine(TutorialRoutine());
    }
    private IEnumerator TutorialRoutine()
    {
        Time.timeScale = 0;
        text1.enabled = true;
        appearTimer = 0;
        while(appearTime>appearTimer)
        {
            appearTimer += Time.deltaTime;
            text1.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while(!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        click.SetActive(false);
        text1.enabled = false;

        text2.enabled = true;
        arrowPosition.SetActive(true);
        arrow.GetComponent<Arrow>().SetPos(new(-974, -540, 0), new(-969, -540, 0));
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

        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(-961.5f, -534, 0),new(-961.5f, -539, 0));
        text3.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text3.alpha = appearTimer / appearTime;
            yield return null;

        }
        while (!tombstone.GetSelect())
        {
            yield return null;
        }
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(-950, -540, 0), new(-956, -540, 0));

        while (ZombieManager.builds.Count<1)
        {
            yield return null;
        }
        arrowPosition.SetActive(false);
        yield return new WaitForSeconds(timeBetweenText);
        text3.enabled = false;

        text4.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text4.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        while (ZombieManager.brains<50)
        {
            yield return null;
        }
        yield return new WaitForSeconds(timeBetweenText);
        text4.enabled = false;

        text5.enabled = true;
        arrowPosition.SetActive(true);
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(-958.5f, -534, 0), new(-958.5f, -539, 0));
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text5.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        while(!zombie.GetSelect())
        {
            yield return null;
        }
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(-950, -540, 0), new(-956, -540, 0));

        while (zombie.GetCanBuy())
        {
            yield return null;
        }
        arrowPosition.SetActive(false);
        yield return new WaitForSeconds(timeBetweenText);
        text5.enabled = false;

        arrowPosition.SetActive(true);
        text6.enabled = true;
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(-961.5f, -534, 0), new(-961.5f, -539, 0));
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text6.alpha = appearTimer / appearTime;
            yield return null;

        }
        while (ZombieManager.builds.Count < 2)
        {
            yield return null;
        }
        text6.enabled = false;
        arrowPosition.SetActive(false);

        text7.enabled = true;
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text7.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        text7.enabled = false;
        click.SetActive(false);

        text8.enabled = true;
        arrowPosition.SetActive(true);
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(-946,- 538, 0), new(-952, -538, 0)) ;

        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text8.alpha = appearTimer / appearTime;
            yield return null;

        }
        yield return new WaitForSeconds(timeBetweenText);
        click.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        text8.enabled = false;
        click.SetActive(false);
        arrowPosition.SetActive(false);
        gameObject.SetActive(false);
    }
}
