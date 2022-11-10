using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody RB;
    public float jumpForce = 2.0f;
    public bool isGrounded = false;
    public bool doubleCount = false;
    public Camera cmr;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            RB.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
            isGrounded = false;
            doubleCount = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && doubleCount==true)
        {
            RB.velocity = Vector3.zero;
            RB.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
            doubleCount = false;
        }

        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("Run", true);
            transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }

        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().SetBool("Run", true);
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            transform.localRotation = Quaternion.Euler(0, 270, 0);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.tag == "Terrain")
        {
            transform.position = new Vector3(-5, 2, 0);
            RB.velocity = Vector3.zero;
            cmr.transform.position = new Vector3(-5, 3, -8);
        }
    }

}
