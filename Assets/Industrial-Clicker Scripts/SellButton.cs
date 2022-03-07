using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class SellButton : MonoBehaviour
{
    [Header("Price RNG")]
    public int priceMin = 2;

    public int priceMax = 10;
    public int price;

    [Header("Quantity RNG")]
    public int quantityMin = 5;

    public int quantityMax = 10;
    public int quantity;

    // Start is called before the first frame update
    private void Start()
    {
        if (price == 0)
        {
            price = Random.Range(priceMin, priceMax);
        }
        if (quantity == 0)
        {
            quantity = Random.Range(quantityMin, quantityMax);
        }
        gameObject.GetComponentInChildren<TMP_Text>().text = gameObject.GetComponentInChildren<TMP_Text>().text.Replace("#", quantity.ToString());
        gameObject.GetComponentInChildren<TMP_Text>().text = gameObject.GetComponentInChildren<TMP_Text>().text.Replace("$", "$" + price.ToString());

        gameObject.GetComponent<Button>().onClick.AddListener(Click); //Roundabout but cleaRLY i don't know buttons as well as I thought I did
        //print(gameObject.name);
    }

    private void Click()
    {
        if (GameObject.Find("$Storage").GetComponent<ResourceStorage>().plank >= quantity)
        {
            GameObject.Find("$Storage").GetComponent<ResourceStorage>().sellPlanks(quantity, price);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}