using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasserbyManager : MonoBehaviour
{
    public GameObject MNPC1;
    public GameObject MNPC2;
    public GameObject MNPC3;
    public GameObject FNPC1;
    public GameObject FNPC2;
    public GameObject FNPC3;

    public int locPicker;

    int npcPicker;
    float timer;
    private float moveSpeed = 0.5f; // Adjust speed as needed

    void Start()
    {
        npcSelector();
        startdisabler();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            npcSelector();
        }
    }

    void startdisabler()
    {
        MNPC1.SetActive(false);
        MNPC2.SetActive(false);
        //MNPC3.SetActive(false);
        FNPC1.SetActive(false);
        FNPC2.SetActive(false);
        FNPC3.SetActive(false);
    }

    void npcSelector()
    {
        locPicker++;
        npcPicker = Random.Range(1, 7);
        timer = Random.Range(1, 5);
        switch (npcPicker)
        {
            case 1:
                MNPC1.SetActive(true);
                break;

            case 2:
                MNPC2.SetActive(true);
                break;

            case 3:
                //MNPC3.SetActive(true);
                break;

            case 4:
                FNPC1.SetActive(true);
                break;

            case 5:
                FNPC2.SetActive(true);
                break;

            case 6:
                FNPC3.SetActive(true);
                break;
        }
    }

}
