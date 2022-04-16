using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public GameObject sphere;
    List<GameObject> spheres;
    // Start is called before the first frame update
    void Start()
    { 
        if (sphere == null)
        {
            sphere = gameObject;
        }
        for (int i = 0; i < 10; i++) {
            print("HEX");
            //GameObject n = GameObject.Instantiate(sphere);
            //spheres[i] = n;
            Vector3 newPos =new Vector3(10*i,0,0);
            // n.transform.position = newPos;
            Instantiate(sphere, newPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
