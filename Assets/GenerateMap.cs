using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;

[ExecuteAlways]
public class GenerateMap : MonoBehaviour
{
    [Serializable]
    public class Cell
    {
        public string id;
        public string terrain;
        public string building;
    }

    [Serializable]
    public class MapData
    {
        public Cell[] CellData;
    }

    private TextAsset file;

    private void OnDrawGizmos()
    {
    }

    private void Awake()
    {
        file = Resources.Load("MapData") as TextAsset;
        print(file.text);
        MapData json = JsonUtility.FromJson<MapData>(file.text);
        Debug.Log(json.CellData);

        foreach (Cell cell in json.CellData)
        {
            print(cell.id);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}