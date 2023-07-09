using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public void MakeInvisible()
    {
        spriteRenderer.enabled = false;
    }

    public void MakeVisible()
    {
        spriteRenderer.enabled = true;
    }
}
