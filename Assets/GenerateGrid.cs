using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public GameObject sphere;
    GameObject[] spheres;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            GameObject n = GameObject.Instantiate(sphere);
            spheres
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
