using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauiseDialogue : MonoBehaviour
{
    public string initialText;

    // Start is called before the first frame update
    private void Start()
    {
        if (initialText == "")
        {
            initialText = gameObject.GetComponent<TMP_Text>().text;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            gameObject.GetComponent<TMP_Text>().text = initialText;
        }
        else
        {
            gameObject.GetComponent<TMP_Text>().text = "";
        }
    }
}