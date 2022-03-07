using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModWealth : MonoBehaviour
{

    int wealth = 0;
    string startText;
    // Start is called before the first frame update
    void Start()
    {
        startText = gameObject.GetComponent<TMP_Text>().text;
        Click.Clicked += (modVal, str) => Mod(1);
        
        //Click.Clicked.AddListener(Mod);
            //+ Mod(1);
    }
    private void Mod(int modVal)
    {
        wealth += modVal;
        gameObject.GetComponent<TMP_Text>().text = startText + wealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
