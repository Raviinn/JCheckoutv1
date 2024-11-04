using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNightManager : MonoBehaviour
{
    public Light lightSource; // Assign this in the Inspector
    public GameObject EnvLightSources;
    public float rotationInterval = 3f; // Time interval in seconds
    private Vector3[] rotationPos = new Vector3[3];
    private int rotationPosCounter;
    private float elapsedTime = 0f;

    private void Start()
    {
        rotationPos[0] = new Vector3(8f, 1216f, -4f);
        lightSource.transform.eulerAngles = rotationPos[0];
        rotationPos[1] = new Vector3(-1f, 1341f, .9f);
        rotationPos[2] = new Vector3(-9f, 1423, 8);
        rotationPosCounter = 0;
        EnvLightSources.SetActive(false);
    }

    private void Update()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the elapsed time exceeds the rotation interval
        if (elapsedTime >= rotationInterval)
        {
            rotationPosCounter++;
            RotateLightSource();
            elapsedTime = 0f; // Reset the elapsed time
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
            rotationPosCounter = -1;
            EnvLightSources.SetActive(true);
        }

    }
}
