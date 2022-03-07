using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceStorage : MonoBehaviour
{
    [Header("initial resources")]
    public int money = 100;

    public int log = 10;
    public int plank = 0;

    [Header("Display Text")]
    public TMP_Text moneyText;

    public TMP_Text logText;
    public TMP_Text plankText;

    [Header("Interactables")]
    public GameObject factory;

    public MeshCollider factoryMeshComponent;
    public Click factoryClickComponent;
    public AudioSource factoryAudio;

    [Header("Time Stuff")]
    public bool gameIsPaused = true;

    private void Start()
    {
        Click.Clicked += (sender, msg) => saw(1);
    }

    private void updateText()
    {
    }

    private void saw(int efficiency)
    {
        log -= efficiency;
        plank += efficiency;

        //TODO: Create option where sawing two logs makes two planks and it's called here
    }

    public void sellPlanks(int quantity, int price) //Assumes user already has quantity
    {
        plank -= quantity;
        money += price;
    }

    public void buyPlanks(int quantity, int price) //Assumes user already has money
    {
        plank += quantity;
        money -= price;
    }

    public void buyLogs(int quantity, int price) //Assumes user already has money
    {
        log += quantity;
        money -= price;
    }

    // Update is called once per frame
    private void Update()
    {
        moneyText.text = money.ToString();
        logText.text = log.ToString();
        plankText.text = plank.ToString();

        if (log > 0 && factoryAudio.enabled)
        {
            factoryMeshComponent.enabled = true;
        }
        else if (factoryAudio.enabled)
        {
            //actoryMeshComponent.ena
            factoryMeshComponent.enabled = false;
        }
    }
}