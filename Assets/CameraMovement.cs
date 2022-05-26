using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 deltaMovement = new Vector3(0, 0, 0);
    public float movementScalar = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            deltaMovement += Vector3.forward*movementScalar;
        }
        if (Input.GetKey(KeyCode.A))
        {

            deltaMovement += Vector3.left*movementScalar;
        }
        if (Input.GetKey(KeyCode.S))
        {

            deltaMovement += Vector3.back * movementScalar;
        }
        if (Input.GetKey(KeyCode.D))
        {

            deltaMovement += Vector3.right * movementScalar;
        }

        if (Input.GetKey(KeyCode.Q))
        {

            deltaMovement += Vector3.up * movementScalar;
        }
        if (Input.GetKey(KeyCode.E))
        {

            deltaMovement += Vector3.down * movementScalar;
        }

        transform.position += deltaMovement;
        deltaMovement = new Vector3(0, 0, 0);
    }
}
