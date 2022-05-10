using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [ExecuteAlways]
    private TextAsset file = Resources.Load("data") as TextAsset;

    private items = JsonUtility.FromJson<ItemArray>(file.text);

    private void OnDrawGizmos()
    {
        print("legs");
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}