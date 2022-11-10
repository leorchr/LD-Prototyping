using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public PlayerController playerController;
    private int cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = playerController.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-cameraSpeed * Time.deltaTime, 0, 0);
        }
    }
}
