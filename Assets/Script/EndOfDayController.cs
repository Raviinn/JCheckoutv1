using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDayController : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickupLayerMask;
    private EndOfDayManager endOfDayManager;
    private float detectDistance;
    public GameObject closedSign;
    public GameObject openSign;
    // Start is called before the first frame update
    void Start()
    {
        detectDistance = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                        out RaycastHit raycastHit, detectDistance, pickupLayerMask))
            {
                if ((raycastHit.transform.TryGetComponent(out endOfDayManager))){
                    if(endOfDayManager.gameObject.name == "ClosedSign")
                    {
                        endOfDayManager.gameObject.SetActive(false);
                        openSign.SetActive(true);
                        GameObject.Find("NPCGenerator").GetComponent<NPCGenerator>().isMartOpen = true;
                    }
                    else if (endOfDayManager.gameObject.name == "OpenSign")
                    {
                        endOfDayManager.gameObject.SetActive(false);
                        closedSign.SetActive(true);
                        GameObject.Find("NPCGenerator").GetComponent<NPCGenerator>().isMartOpen = false;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (closedSign.activeSelf)
            {
                GameObject.Find("DirectionalLight").GetComponent<DayandNightManager>().isEndOfDay = true;
                GameObject.Find("DayTracker").GetComponent<DayTrackerManager>().dayCount++;
                GameObject.Find("DayTracker").GetComponent<DayTrackerManager>().UpdateDate();
            }
        }
    }
}
