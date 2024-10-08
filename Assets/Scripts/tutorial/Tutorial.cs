using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject click;
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
        arrow.SetActive(true);
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, 0));
        arrow.GetComponent<Arrow>().SetPos(new(-13.65f, 0, 0), new(-9.3f, 0, 0));
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
        arrow.GetComponent<Arrow>().SetPos(new(-1.4f, 6.33f, 0),new(-1.4f, 3.76f, 0));
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
        arrow.GetComponent<Arrow>().SetPos(new(10.55f, 0, 0), new(7, 0, 0));

        while (ZombieManager.builds.Count<1)
        {
            yield return null;
        }
        arrow.SetActive(false);
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
        arrow.SetActive(true);
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(1.3f, 6.33f, 0), new(1.3f, 3.76f, 0));
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text5.alpha = appearTimer / appearTime;
            yield return null;

        }
        while(!zombie.GetSelect())
        {
            yield return null;
        }
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(10.55f, 0, 0), new(7, 0, 0));

        while (zombie.GetCanBuy())
        {
            yield return null;
        }
        arrow.SetActive(false);
        yield return new WaitForSeconds(timeBetweenText);
        text5.enabled = false;

        arrow.SetActive(true);
        text6.enabled = true;
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -90));
        arrow.GetComponent<Arrow>().SetPos(new(-1.4f, 6.33f, 0), new(-1.4f, 3.76f, 0));
        appearTimer = 0;
        while (appearTime > appearTimer)
        {
            appearTimer += Time.deltaTime;
            text6.alpha = appearTimer / appearTime;
            yield return null;

        }
        while(!tombstone.GetSelect())
        {
            yield return null;
        }
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(10.55f, 0, 0), new(7, 0, 0));

        while (ZombieManager.builds.Count < 2)
        {
            yield return null;
        }
        text6.enabled = false;

        text7.enabled = true;
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, 90));
        arrow.GetComponent<Arrow>().SetPos(new(-17, -4, 0), new(-17, -1, 0));
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
        arrow.transform.rotation = Quaternion.Euler(new(0, 0, -180));
        arrow.GetComponent<Arrow>().SetPos(new(14,1.5f, 0), new(9, 1.5f, 0)) ;

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
        arrow.SetActive(false);
        gameObject.SetActive(false);
    }
}
