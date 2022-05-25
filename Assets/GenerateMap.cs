using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;

[ExecuteAlways]
public class GenerateMap : MonoBehaviour
{
    public GameObject Map;
    //
    public GameObject plains;
    public GameObject mine; 
    //
    public Dictionary<string,UnityCell> MapData = new Dictionary<string, UnityCell>();

    public Dictionary<string, UnityCell> AdditiveMapData = new Dictionary<string, UnityCell>();

   

    [Serializable]
    public class JSONCell
    {
        public string id, terrain, building;
    }

    [Serializable]
    public class JSONMapData
    {
        public JSONCell[] JSONCellData;
    }

    private TextAsset file;

    private void OnDrawGizmos()
    {
    }

    public class UnityCell
    {
        public int x, z;
        public string terrain, building, id;

        public UnityCell(string _id, string _terrain, string _building)
        {
            x = Int32.Parse(_id.Split(",")[0]);
            z = Int32.Parse(_id.Split(",")[1]);
            id = _id;
            terrain = _terrain;
            building = _building;
        }
    }

    public class UnityVoxel
    {
        public int x, y, z;
        public string terrain, building, unit;
    }

    /*
    public UnityCell toUnityCell(int x, int y, string terrain, string building)
    {
        UnityCell tempCell = new UnityCell(x
        tempCell.x = x;

        return tempCell;
    }
    */

    private void Awake()
    {
        file = Resources.Load("JSONMapData") as TextAsset;
        //print(file.text);
        JSONMapData json = JsonUtility.FromJson<JSONMapData>(file.text);
        //Debug.Log(json.JSONCellData);

        foreach (JSONCell cell in json.JSONCellData)
        {
            MapData[cell.id] = (new UnityCell(cell.id, cell.terrain, cell.building));
            //print("added");
            //print(MapData[0].building);
        }
        //Make additive map data = map data
        AdditiveMapData = new Dictionary<string, UnityCell>(MapData);
        

        foreach (Transform child in Map.transform)
        {
            //Cull the nonexistent tiles
            try
            {
                if (MapData[child.name] != null)
                {

                    //print("child " + child.name + " Is present in MapData");

                    AdditiveMapData.Remove(child.name);
                }
            }
            catch (KeyNotFoundException)
            {
                //print("except " + e);
               // print("child " + child.name + " Is not in MapData");
                GameObject.DestroyImmediate(child.gameObject);
            }

        }
        foreach (KeyValuePair<string,UnityCell> kvp in AdditiveMapData)
        {
            print(kvp.Key);
            if (AdditiveMapData[kvp.Key].terrain == "plains")
            {

                GameObject newCell = Instantiate(plains, new Vector3(AdditiveMapData[kvp.Key].x*10, 0, AdditiveMapData[kvp.Key].z * 10), Quaternion.identity);
                newCell.transform.SetParent(Map.transform);
                newCell.name = kvp.Key;
            }
        }
         
    }

    // Update is called once per frame
    private void Update()
    {
    }
}