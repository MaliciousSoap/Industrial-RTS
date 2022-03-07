using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        print("started");
    }
    void Update()    // Or FixedUpdate() for physical stuf
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            
            if (hit.collider != null)
            {
                // Find the hit reciver (if existant) and call the method
                var hitReciver = hit.collider.gameObject.GetComponent<HitReciver>();
                if (hitReciver != null)
                {
                    hitReciver.OnRayHit();
                }
            }
        }
    }
}