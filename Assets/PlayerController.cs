using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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
    public Vector3 playerPosition;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        playerPosition = transform.position;

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
        }

        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().SetBool("Run", true);
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
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
            transform.position = playerPosition;
            RB.velocity = Vector3.zero;
            cmr.transform.localPosition = new Vector3(11.42857f, -0.942857f, 0);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position += new Vector3(6, 0, 0);
            transform.position = new Vector3(transform.position.x, 5, 0);
            playerPosition = transform.position;
            RB.velocity = Vector3.zero;
            cmr.transform.localPosition = new Vector3(11.42857f, 1, 0);
        }
    }
}
