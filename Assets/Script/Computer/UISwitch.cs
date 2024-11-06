using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    public void open()
    {
        UI.SetActive(true);
    }

    public void close()
    {
        UI.SetActive(false);
    }
}
