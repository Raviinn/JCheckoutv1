using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject NPCCheckpoints;
    public GameObject npc;
    public GameObject Shelves;
    private float rotationSpeed;
    private int randomCheckpointNumGenerator;
    private int randomShelfPlatformChecker;
    public GameObject boughtItems;
    public GameObject grabPoint;

    private bool isGoingtoMart, isGoingtoCashier;
    public float moveSpeed; // Speed of movement
    private int targetCount;
    private bool thereIsItemInShelf;
    private void Start()
    {
        isGoingtoMart = false;
        isGoingtoCashier = false;
        rotationSpeed = 20f;
        randomCheckpointNumGenerator = 0;
        thereIsItemInShelf = false;
    }
    private void Update()
    {
        Vector3 targetPosition;
        if (!isGoingtoMart && !isGoingtoCashier)
        {
            targetPosition = NPCCheckpoints.transform.GetChild(0).transform.position;
        }
        else if (isGoingtoMart && !isGoingtoCashier)
        {
            targetPosition = NPCCheckpoints.transform.GetChild(randomCheckpointNumGenerator).transform.position;
        }
        else if (isGoingtoCashier)
        {
            npc.GetComponent<Rigidbody>().isKinematic = false;
            targetPosition = NPCCheckpoints.transform.GetChild(5).transform.position;
        }
        else
        {
            return; // No movement
        }

        // Move the NPC
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPosition,
            moveSpeed * Time.deltaTime);

        // Rotate the NPC to face the direction of movement
        Vector3 direction = (targetPosition - npc.transform.position).normalized;
        if (direction != Vector3.zero) // Ensure we have a valid direction
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, targetRotation,
                rotationSpeed * Time.deltaTime);
        }

        // Check if the NPC has reached the first checkpoint
        if (!isGoingtoMart && npc.transform.position == NPCCheckpoints.transform.GetChild(0).transform.position)
        {
            npc.transform.SetParent(NPCCheckpoints.transform.GetChild(0).transform);
            StartCoroutine(WaitForDelayToStore());
            
        }

        // Check if the NPC has reached a random checkpoint while going to mart
        if (isGoingtoMart && npc.transform.position == NPCCheckpoints.transform.GetChild(randomCheckpointNumGenerator).transform.position)
        {
            npc.transform.SetParent(NPCCheckpoints.transform.GetChild(randomCheckpointNumGenerator).transform);
            Vector3 directionShelf1 = (Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).
                transform.position - npc.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionShelf1);
            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, targetRotation,
                rotationSpeed * Time.deltaTime);

            StartCoroutine(WaitForDelayToStore());

            if (randomCheckpointNumGenerator == 5)
            {
                isGoingtoMart = false;
                StartCoroutine(WaitForDelayToCashier());
            }
            
        }

        // Check if the NPC has reached the cashier
        if (isGoingtoCashier && npc.transform.position == NPCCheckpoints.transform.GetChild(5).transform.position)
        {
            npc.transform.SetParent(NPCCheckpoints.transform.GetChild(5).transform);
            npc.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private IEnumerator WaitForDelayToStore()
    {
        if (!isGoingtoMart)
        {
            yield return new WaitForSeconds(0);
            randomCheckpointNumGenerator = Random.Range(1, 5);
            //randomCheckpointNumGenerator = 3;
            isGoingtoMart = true;
        }
        else if (isGoingtoMart)
        {
            yield return new WaitForSeconds(5f);
            Debug.Log(randomCheckpointNumGenerator);
            if (randomCheckpointNumGenerator != 5)
            {
                randomShelfPlatformChecker = Random.Range(1, 4);
                Debug.Log(randomShelfPlatformChecker);
                /*for (int i = 0; i < 6; i++)
                {
                    if (Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1").transform.GetChild(i).gameObject.
                    activeSelf == true)
                    {
                        Debug.Log("An item placed in container");
                        Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1").transform.GetChild(i).transform.position = grabPoint.transform.position;
                        Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1").transform.GetChild(i).transform.SetParent(boughtItems.transform);
                        
                        
                        //get items from shelf and transfer to NPC
                    }
                    else
                    {
                        Debug.Log("No item in container");
                    }
                }*/
                 
            }
            randomCheckpointNumGenerator = Random.Range(1, 6);

        }
        StopAllCoroutines();
    }

    private IEnumerator WaitForDelayToCashier()
    {
        yield return new WaitForSeconds(1f);
        isGoingtoCashier = true;
        Debug.Log("Tapos");
        
        
    }

}
