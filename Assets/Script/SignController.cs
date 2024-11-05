using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_open = false;
    public GameObject opensign;
    public GameObject closesign;

    void Start()
    {
        opensign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (is_open == false)
            {
                Debug.Log("Open");
                is_open = true;
                opensign.SetActive(true);
                closesign.SetActive(false);
            }
            else
            {
                Debug.Log("Close");
                is_open = false;
                opensign.SetActive(false);
                closesign.SetActive(true);
            }
        }
    }
}
