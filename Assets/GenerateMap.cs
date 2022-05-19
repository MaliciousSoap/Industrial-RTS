using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;

[ExecuteAlways]
public class GenerateMap : MonoBehaviour
{
    [Serializable]
    public class JSONCell
    {
        public string id, terrain, building;
    }

    [Serializable]
    public class MapData
    {
        public JSONCell[] CellData;
    }

    private TextAsset file;

    private void OnDrawGizmos()
    {
    }

    public class UnityCell
    {
        public int centerX, centerY, centerZ;
        public string terrain, building, unit;
    }

    private void Awake()
    {
        UnityCell[] UnityMapData;

        //--
        file = Resources.Load("MapData") as TextAsset;
        print(file.text);
        MapData json = JsonUtility.FromJson<MapData>(file.text);
        Debug.Log(json.CellData);

        foreach (JSONCell cell in json.CellData)
        {
            print(cell.id);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}