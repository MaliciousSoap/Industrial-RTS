using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Click.Clicked += (sender, args) => launchBox();
    }

    private void summonWood()
    {
        GameObject clone = Instantiate(gameObject, new Vector3(0, 2, 0), Quaternion.identity);
        clone.transform.rotation = Quaternion.Euler(90, 45, 0);
        //clone.GetComponent<launch>().enabled = false;
        clone.GetComponent<Rigidbody>().useGravity = true;
        clone.GetComponent<AudioSource>().Play();
        clone.GetComponent<Rigidbody>().AddForce(transform.up * 100);
        clone.GetComponent<Rigidbody>().AddForce(transform.right * 1000);
        clone.GetComponent<launch>().enabled = false;
        Destroy(clone, 10);
    }

    private void launchBox()
    {
        if (gameObject != null)
        {
            summonWood();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //launchBox();
    }
}