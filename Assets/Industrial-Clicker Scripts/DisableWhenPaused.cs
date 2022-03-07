using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenPaused : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            foreach (var com in gameObject.GetComponents<MeshCollider>())
            {
                com.enabled = false;
            }
            foreach (var com in gameObject.GetComponents<BoxCollider>())
            {
                com.enabled = false;
            }
            foreach (var aud in gameObject.GetComponents<AudioSource>())
            {
                aud.enabled = false;
            }
        }
        else if (Time.timeScale == 1)
        {
            foreach (var com in gameObject.GetComponents<MeshCollider>())
            {
                com.enabled = true;
            }
            foreach (var com in gameObject.GetComponents<BoxCollider>())
            {
                com.enabled = true;
            }
            foreach (var aud in gameObject.GetComponents<AudioSource>())
            {
                aud.enabled = true;
            }
        }
    }
}