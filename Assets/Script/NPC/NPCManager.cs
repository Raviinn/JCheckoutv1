using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject NPCCheckpoints;
    public GameObject npc;
    public GameObject Shelves;
    public GameObject Cashier;
    private float rotationSpeed;
    private int randomCheckpointNumGenerator;
    private int randomShelfPlatformChecker;
    public GameObject boughtItems;
    public GameObject grabPoint;
    public bool isDone;
    public float totalGroceryPrice;
    private Animator animator;

    public Vector3 targetPosition;

    private bool isGoingtoMart, isGoingtoCashier;
    public float moveSpeed; // Speed of movement
    private int targetCount;
    private bool thereIsItemInShelf;
    private bool isExiting;
    public float npcPayment;
    private bool hasGeneratedRandomNum;
    private void Start()
    {
        isGoingtoMart = false;
        isGoingtoCashier = false;
        rotationSpeed = 20f;
        randomCheckpointNumGenerator = 0;
        thereIsItemInShelf = false;
        isDone = false;
        totalGroceryPrice = 0;
        isExiting = false;
        npcPayment = 0; ;
        hasGeneratedRandomNum = false;
        animator = npc.transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("is_waiting", false);
        //Debug.Log("Total Bill: " + totalGroceryPrice);
        if (!NPCCheckpoints.GetComponent<NPCCheckPointManager>().npcExit)
        {
            if (!isGoingtoMart && !isGoingtoCashier)
            {
                targetPosition = NPCCheckpoints.transform.Find($"Checkpoint{randomCheckpointNumGenerator}").
                    transform.position;
            }
            else if (isGoingtoMart && !isGoingtoCashier)
            {
                if (randomCheckpointNumGenerator < 11)
                {
                    targetPosition = NPCCheckpoints.transform.Find($"Checkpoint{randomCheckpointNumGenerator}").
                        transform.position;
                }
                else
                {
                    targetPosition = NPCCheckpoints.transform.Find("CheckPointCashier").
                                        transform.position;
                }

            }
            else if (!isGoingtoMart && isGoingtoCashier)
            {
                targetPosition = NPCCheckpoints.transform.Find("CheckPointCashier").transform.position;
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

            if (randomCheckpointNumGenerator < 11)
            {
                animator.SetBool("is_waiting", true);
                if (isGoingtoMart && npc.transform.position == NPCCheckpoints.transform.Find($"Checkpoint{randomCheckpointNumGenerator}")
                .transform.position)
                {
                    npc.transform.SetParent(NPCCheckpoints.transform.Find($"Checkpoint{randomCheckpointNumGenerator}").
                        transform);
                    Vector3 directionShelf = (Shelves.transform.Find($"Shelf{randomCheckpointNumGenerator}").
                        transform.position - npc.transform.position).normalized;
                    Quaternion targetRotation = Quaternion.LookRotation(directionShelf);
                    npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, targetRotation,
                        rotationSpeed * Time.deltaTime);

                    StartCoroutine(WaitForDelayToStore());
                    //Debug.Log("Next checkpoint is: " + randomCheckpointNumGenerator);

                }
            }

            if (randomCheckpointNumGenerator >= 11)
            {
                //Debug.Log("Last number is " + randomCheckpointNumGenerator);
                isGoingtoMart = false;
                isGoingtoCashier = true;
                npc.transform.SetParent(NPCCheckpoints.transform.Find("CheckPointCashier").transform);
                StartCoroutine(WaitForDelayToCashier());
            }

            // Check if the NPC has reached the cashier
            if (isGoingtoCashier && npc.transform.position == NPCCheckpoints.transform.Find("CheckPointCashier").
                transform.position)
            {
                animator.SetBool("is_waiting", true);
                if (!hasGeneratedRandomNum)
                {
                    GenerateNPCPayment();
                    hasGeneratedRandomNum = true;
                }
                Vector3 directionCashier = (Cashier.transform.position - npc.transform.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(directionCashier);
                npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, targetRotation,
                    rotationSpeed * Time.deltaTime);
                npc.GetComponent<Rigidbody>().isKinematic = true;
                npc.transform.Find("NPC/NPCBasket/Basket").gameObject.SetActive(true);
                npc.transform.Find("NPC/NPCBasket/Basket").gameObject.transform.position = Cashier.transform.
                    Find("Cashier/Group1/Mesh1/GroceryHolder").position;
            }
        }

        else
        {
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

            if (NPCCheckpoints.GetComponent<NPCCheckPointManager>().npcExit == true &&
                npc.transform.position != NPCCheckpoints.transform.Find("Checkpoint0").
                transform.position && !isExiting)
            {
                npc.transform.SetParent(NPCCheckpoints.transform.Find("Checkpoint0").transform);
                npc.transform.Find("NPC/NPCBasket/Basket").gameObject.SetActive(false);
                targetPosition = NPCCheckpoints.transform.Find("Checkpoint0").transform.position;
                //NPC Exits store
            }

            if (NPCCheckpoints.GetComponent<NPCCheckPointManager>().npcExit == true &&
                npc.transform.position == NPCCheckpoints.transform.Find("Checkpoint0").
                transform.position && !isExiting)
            {
                npc.transform.SetParent(NPCCheckpoints.transform.Find("ExitPoint1").transform);
                targetPosition = NPCCheckpoints.transform.Find("ExitPoint1").transform.position;
                isExiting = true;
                //NPC Exits store
            }

            if (isExiting && npc.transform.position == NPCCheckpoints.transform.Find("ExitPoint1").
                transform.position)
            {
                Destroy(npc);
            }

        }
    }

    private IEnumerator WaitForDelayToStore()
    {
        if (!isGoingtoMart)
        {
            yield return new WaitForSeconds(0);
            //randomCheckpointNumGenerator = Random.Range(1, 11);
            randomCheckpointNumGenerator = 4;
            isGoingtoMart = true;
        }
        else if (isGoingtoMart)
        {
            yield return new WaitForSeconds(5f);
            //Debug.Log(randomCheckpointNumGenerator);
            if (randomCheckpointNumGenerator != 5)
            {
                animator.SetBool("is_waiting", true);
                //Debug.Log("Pasok");
                randomShelfPlatformChecker = Random.Range(1, 4);
                Debug.Log(randomShelfPlatformChecker);
                for (int i = 1; i < 7; i++)
                {
                    Debug.Log(i);     
                    if (Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1/Item{i}").gameObject.activeSelf == true)
                    {
                        boughtItems.SetActive(true);
                        Debug.Log("An item placed in container");
                        totalGroceryPrice = totalGroceryPrice + Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1/Item{i}").transform.GetChild(0).GetComponent<ObjectGrabbable>().objectPrice;
                        Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1/Item{i}").transform.GetChild(0).transform.position = grabPoint.transform.position;
                        Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1/Item{i}").transform.GetChild(0).transform.SetParent(boughtItems.transform);
                        Shelves.transform.GetChild(randomCheckpointNumGenerator - 1).transform.
                    Find($"Stands/Platform1/Item{i}").gameObject.SetActive(false);
                        boughtItems.SetActive(false);
                        break;

                        //get items from shelf and transfer to NPC
                    }
                    else
                    {
                        Debug.Log("No item in container");
                    }
                }
                 
            }
            animator.SetBool("is_waiting", false);
            randomCheckpointNumGenerator = Random.Range(1, 20);
        }
        StopAllCoroutines();
    }

    private IEnumerator WaitForDelayToCashier()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log("Tapos");
        StopAllCoroutines();

    }

    private void GenerateNPCPayment()
    {
        int randomnNum = Random.Range(0, 200);
        if (randomnNum == 0)
        {
            npcPayment = totalGroceryPrice;
        }
        else
        {
            npcPayment = totalGroceryPrice + randomnNum;
        }
    }

}
