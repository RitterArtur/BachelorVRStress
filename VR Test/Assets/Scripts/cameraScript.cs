using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float CameraSpeed = 2.0f;


    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0);
        }
        // Rotate right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0);
        }
        // Strafe left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed;
        }
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }
        // Move backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }
        // Strafe right     
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += speed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }

        yaw += CameraSpeed * Input.GetAxis("Mouse X");


        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}
