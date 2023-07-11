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
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Vérifie si le collider cliqué est celui que vous souhaitez
                if (hit.collider.CompareTag("BuyTab"))
                {
                    // Réalisez les actions souhaitées
                    hit.collider.GetComponent<BuyHolder>().OnMouseClic();
                }
                else if (hit.collider.CompareTag("Brain"))
                {
                    // Réalisez les actions souhaitées
                    hit.collider.GetComponent<BrainItem>().OnMouseClic();
                }
            }
        }
    }
}
