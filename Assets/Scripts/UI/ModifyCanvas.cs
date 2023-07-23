using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyCanvas : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public void MakeInvisible()
    {
        // D�sactiver le composant SpriteRenderer pour rendre le sprite invisible
        canvas.enabled = false;
    }

    public void MakeVisible()
    {
        // R�activer le composant SpriteRenderer pour rendre le sprite visible
        canvas.enabled = true;
    }
}
