using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayandNightManager : MonoBehaviour
{
    public Light lightSource; // Assign this in the Inspector
    public GameObject EnvLightSources;
    public float rotationInterval = 3f; // Time interval in seconds
    private Vector3[] rotationPos = new Vector3[3];
    private int rotationPosCounter;
    private float elapsedTime = 0f;
    public bool isEndOfDay;
    public GameObject noMoreCustomersTxt;

    private void Start()
    {
        rotationPos[0] = new Vector3(18f, 191f, 0f);
        lightSource.transform.eulerAngles = rotationPos[0];
        rotationPos[1] = new Vector3(22f, 191f, 0f);
        rotationPos[2] = new Vector3(-9f, 1423, 8);
        rotationPosCounter = 0;
        EnvLightSources.SetActive(false);
        isEndOfDay = false;
    }

    private void Update()
    {
        
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;
        if (isEndOfDay)
        {
            rotationPosCounter = 0;
            RotateLightSource();
            noMoreCustomersTxt.SetActive(false);
            GameObject.Find("NPCGenerator").GetComponent<NPCGenerator>().isTooLateforCustomers = false;
            isEndOfDay = false;
        }

        // Check if the elapsed time exceeds the rotation interval
        if (elapsedTime >= rotationInterval)
        {
            if (rotationPosCounter != 2)
            {
                rotationPosCounter++;
                RotateLightSource();
                elapsedTime = 0f; // Reset the elapsed time
            }
            else
            {
                
                elapsedTime = 0f;
                noMoreCustomersTxt.SetActive(true);
                noMoreCustomersTxt.GetComponent<Text>().text = "No More Customers Coming";
                GameObject.Find("NPCGenerator").GetComponent<NPCGenerator>().isTooLateforCustomers = true;
            }
        }
    }

    private void RotateLightSource()
    {
        lightSource.transform.eulerAngles = rotationPos[rotationPosCounter];
        if (rotationPosCounter < 2)
        {
            EnvLightSources.SetActive(false);
            
        }
        else
        {
            EnvLightSources.SetActive(true);
        }

    }
}
