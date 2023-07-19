using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicCamera : MonoBehaviour
{
    [SerializeField] private BuyHolder[] buyTabs;

    private bool flag;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);
            flag = false;
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent<Pause>(out Pause component))
                {
                    component.SwitchPause();
                    flag = true;
                    break;
                }
                else if (!Pause.pause && hit.collider.TryGetComponent<BrainItem>(out BrainItem component2))
                {
                    component2.OnMouseClic();
                    flag = true;
                    break;
                }

                else if (!Pause.pause && hit.collider.TryGetComponent<BuyHolder>(out BuyHolder component3))
                {
                    component3.OnMouseClic();
                    flag = true;
                    break;
                }
                else if (!Pause.pause && hit.collider.TryGetComponent<SwitchTab>(out SwitchTab component4))
                {
                    component4.OnClick();
                    flag = true;
                    break;
                }
            }
            if(!Pause.pause && !flag)
            {
                for (int i = 0; i < Mathf.Min(3 + Transporter.unlockedZombie, 6); i++)
                {
                    buyTabs[i].ClickMap();
                }
            }
        }
    }
}
