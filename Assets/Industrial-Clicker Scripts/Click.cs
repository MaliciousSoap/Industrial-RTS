using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click : MonoBehaviour
{
    public delegate void ClickManager(object sender, string args);

    public static event ClickManager Clicked;

    //UnityEvent Clicked(object sender, string args);
    private bool exitTrue = false;

    public Renderer _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        startcolor = _renderer.material.color;
    }

    // Start is called before the first frame update
    private Color startcolor;

    private void OnMouseEnter()
    {
        exitTrue = false;

        _renderer.material.color = Color.yellow;
    }

    private void OnMouseDown()//On click
    {
        _renderer.material.color = Color.black;
    }

    private void OnMouseUp()
    {
        Clicked.Invoke(gameObject, null);
        if (!exitTrue)
        {
            _renderer.material.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        // print("mouseExited");
        exitTrue = true;
        _renderer.material.color = startcolor;
    }
}