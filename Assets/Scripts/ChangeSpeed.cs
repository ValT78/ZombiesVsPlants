using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    [SerializeField] private SpriteRenderer thisSprite;
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private float gameSpeed;


    private void OnMouseDown()
    {
        Transporter.gameSpeed = gameSpeed;
        SwitchColor();
        
    }

    public void SwitchColor()
    {
        thisSprite.color = Color.black;
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = Color.white;
        }
    }
    private void OnEnable()
    {
        if(Transporter.gameSpeed==gameSpeed)
        {
            SwitchColor();
        }
    }
}
