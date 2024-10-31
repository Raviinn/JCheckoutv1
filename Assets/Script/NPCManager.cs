using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject NPCCheckpoints;
    public GameObject npc;

    private bool isGoingtoMart, isGoingtoCashier;
    public float moveSpeed = 0.000001f; // Speed of movement
    private int targetCount;
    private void Start()
    {
        isGoingtoMart = false;
        isGoingtoCashier = false;
    }
    private void Update()
    {
        if (!isGoingtoMart && !isGoingtoCashier)
        {
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, 
                NPCCheckpoints.transform.GetChild(0).transform.position, moveSpeed);
        }else if (isGoingtoMart && !isGoingtoCashier)
        {
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, 
                NPCCheckpoints.transform.GetChild(1).transform.position, moveSpeed);
        }else if (isGoingtoCashier)
        {
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, 
                NPCCheckpoints.transform.GetChild(5).transform.position, moveSpeed);
        }
    
        
        if (npc.transform.position == NPCCheckpoints.transform.GetChild(0).transform.position && !isGoingtoMart)
        {
            npc.transform.SetParent(NPCCheckpoints.transform.GetChild(0).transform);
            StartCoroutine(WaitForDelayToStore());
            
        }

        if (npc.transform.position == NPCCheckpoints.transform.GetChild(1).transform.position)
        {
            npc.transform.SetParent(NPCCheckpoints.transform.GetChild(1).transform);
            StartCoroutine(WaitForDelayToCashier());

        }
     
        if (npc.transform.position == NPCCheckpoints.transform.GetChild(5).transform.position)
        {
            npc.transform.SetParent(NPCCheckpoints.transform.GetChild(5).transform);
            npc.GetComponent<Rigidbody>().isKinematic = true;

        }
    }

    private IEnumerator WaitForDelayToStore()
    {
        yield return new WaitForSeconds(5f);
        isGoingtoMart = true;
        Debug.Log("Going to mart!");
    }

    private IEnumerator WaitForDelayToCashier()
    {
        yield return new WaitForSeconds(5f);
        isGoingtoCashier = true;
        Debug.Log("Going to cashier!");
    }

}
