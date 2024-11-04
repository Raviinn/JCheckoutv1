using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryClose : MonoBehaviour
{
    public GameObject compUI;
    // Start is called before the first frame update
    void Start()
    {
        compUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
