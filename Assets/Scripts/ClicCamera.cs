using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicCamera : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("BuyTab"))
                    {
                        hit.collider.GetComponent<BuyHolder>().OnMouseClic();
                    }
                    else if (hit.collider.CompareTag("Brain"))
                    {
                        hit.collider.GetComponent<BrainItem>().OnMouseClic();
                    }
                }
            }
        }
    }
}
