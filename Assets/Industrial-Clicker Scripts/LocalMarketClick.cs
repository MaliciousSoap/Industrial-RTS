using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMarketClick : MonoBehaviour
{
    public List<GameObject> toShade;
    private List<Color> originalColors = new List<Color>();

    // Start is called before the first frame update
    private void Start()
    {
        //print(toShade[0].GetComponent<MeshRenderer>().materials[0].color == null);
        int i = 0;
        foreach (GameObject gb in toShade)
        {
            //print(gb == null);
            //while (gb.GetComponent<Renderer>() != null )

            originalColors.Add(gb.GetComponent<MeshRenderer>().materials[0].color);
            //gb.GetComponent<MeshRenderer>().material.color = originalColors[i];
            i++;
        }
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<AudioSource>().Play();
        int i = 0;
        foreach (GameObject gb in toShade)
        {
            gb.GetComponent<MeshRenderer>().materials[0].color = originalColors[i] + new Color(-0.1f, -0.1f, -0.1f);
            i += 1;
        }
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        int i = 0;
        foreach (GameObject gb in toShade)
        {
            gb.GetComponent<MeshRenderer>().materials[0].color = originalColors[i];
            i += 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}