using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    private Color initialColor;
    public Color hoverColorMod = new Color(100, 100, 100, 0);
    public Color selectColorMod = new Color(13, 13, 13, 0);

    private bool selected = false;
    private bool clicked = false;

    // Start is called before the first frame update
    private void Start()
    {
        initialColor = gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnMouseOver()
    {
        if (clicked == false)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", initialColor - hoverColorMod);
        }
    }

    private void OnMouseUpAsButton()
    {
        clicked = !clicked;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", initialColor - selectColorMod);
        print("cliquer");
    }

    private void OnMouseDown()
    {
    }

    private void OnMouseExit()
    {
        if (!clicked)
        {
            gameObject.GetComponent<Renderer>().material.color = initialColor;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}