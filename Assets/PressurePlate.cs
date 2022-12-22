using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position += new Vector3(0, -0.5f, 0);
            door.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
    }
}
