using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasserbyController : MonoBehaviour
{
    public PasserbyManager manager;
    public int locPicked;
    public float zPicked;
    public float moveSpeed = 1;

    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        locPicked = manager.locPicker;
        zPicked = Random.Range(-15.6f, -17.6f);

        if (locPicked % 2 == 0)
        {
            transform.position = new Vector3(-28f, 0f, zPicked);
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        if (locPicked % 2 == 1)
        {
            transform.position = new Vector3(22f, 0f, zPicked);
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }

    private void Update()
    {
        if (locPicked % 2 == 0)
        {
            transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawn1"))
        {
            if (locPicked % 2 == 1)
            {
                transform.position = new Vector3(22f, 0f, zPicked);
                targetObject.SetActive(false);
            }
        }

        if (other.CompareTag("Spawn2"))
        {
            if (locPicked % 2 == 0)
            {
                transform.position = new Vector3(-28f, 0f, zPicked);
                targetObject.SetActive(false);
            }
        }
    }
}
