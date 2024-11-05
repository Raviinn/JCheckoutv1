using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CashierController : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickupLayerMask;
    private CashierManager cashierManager;
    private float detectDistance;
    public GameObject player;
    public GameObject playerCheckPoint;
    public GameObject NPCCheckpoints;
    public GameObject cashierPanel;
    public GameObject mouseLook;
    public GameObject[] moneyPrefab;
    public GameObject cashier;
    public Text totalBill;
    public Text paymentAmt;
    public Text change;
    public Text userChange;
    public GameObject endTransaction;
    private float playerChange;
    private float npcPayment; // Will get value from NPC
    private float changes;

    // Start is called before the first frame update
    void Start()
    {
        detectDistance = 7f;
        playerChange = 0;
        npcPayment = 40;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCashier();
    }

    private void HandleCashier()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<CharacterController>().enabled == true)
            {
                if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                    out RaycastHit raycastHit, detectDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out cashierManager))
                    {
                        try
                        {
                            player.GetComponent<CharacterController>().enabled = false;
                        }catch (System.Exception)
                        {

                        }
                        
                        player.transform.position = playerCheckPoint.transform.GetChild(0).position;
                        Debug.Log("Cashier");

                    }

                }
            }else
                player.GetComponent<CharacterController>().enabled = true;
        }

        if (NPCCheckpoints.transform.Find("CheckPointCashier").transform.childCount != 0)
        {
            changes = npcPayment - NPCCheckpoints.transform.Find("CheckPointCashier").transform.GetChild(0).
                            GetComponent<NPCManager>().totalGroceryPrice; 
            
            if (playerChange == changes)
            {
                endTransaction.SetActive(true);
                
            }
            else
            {
                
                endTransaction.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<CharacterController>().enabled == false)
            //Enable Cashier UI when NPC is in Position
        {
            if (NPCCheckpoints.transform.Find("CheckPointCashier").transform.childCount != 0)
            {
                //Close UI
                if (cashierPanel.activeSelf == true)
                {
                    
                    mouseLook.GetComponent<MouseLook>().isInCashier = false;
                    cashierPanel.SetActive(false);
                }
                //Open UI
                else
                {
                    change.text = "Change: " + (npcPayment - NPCCheckpoints.transform.Find("CheckPointCashier").transform.GetChild(0).
                        GetComponent<NPCManager>().totalGroceryPrice);
                    paymentAmt.text = "Payment: " + npcPayment;
                    totalBill.text = "Total Bill: " + NPCCheckpoints.transform.Find("CheckPointCashier").transform.GetChild(0).
                        GetComponent<NPCManager>().totalGroceryPrice+"P";
                    mouseLook.GetComponent<MouseLook>().isInCashier = true;
                    cashierPanel.SetActive(true);

                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && player.GetComponent<CharacterController>().enabled == false)
        {
            NPCCheckpoints.GetComponent<NPCCheckPointManager>().npcExit = true;
        } 
    }

    public void GiveChange1()
    {
        //put money into cash location
        GameObject money = Instantiate(moneyPrefab[0], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position,
            Quaternion.identity);
        money.transform.SetParent(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform);
        playerChange += 1;
        UpdateChange();
    }

    public void GiveChange5()
    {
        //put money into cash location
        GameObject money = Instantiate(moneyPrefab[1], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position,
            Quaternion.identity);
        money.transform.SetParent(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform);
        playerChange += 5;
        UpdateChange();
    }

    public void GiveChange10()
    {
        //put money into cash location
        GameObject money = Instantiate(moneyPrefab[2], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position,
            Quaternion.identity);
        money.transform.SetParent(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform);
        playerChange += 10;
        UpdateChange();
    }
    public void GiveChange20()
    {
        //put money into cash location
        GameObject money = Instantiate(moneyPrefab[3], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position, 
            Quaternion.identity);
        money.transform.SetParent(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform);
        playerChange += 20;
        UpdateChange();
    }

    public void GiveChange50()
    {
        //put money into cash location
        GameObject money = Instantiate(moneyPrefab[4], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position,
            Quaternion.identity);
        money.transform.SetParent(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform);
        playerChange += 50;
        UpdateChange();
    }
    public void GiveChange100()
    {
        //put money into cash location
        GameObject money = Instantiate(moneyPrefab[5], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position,
            Quaternion.identity);
        money.transform.SetParent(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform);
        playerChange += 100;
        UpdateChange();
    }

    private void UpdateChange()
    {
        userChange.text = "Player Change: " + playerChange;
    }

    public void RemoveChange()
    {
        int count = cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.childCount - 1;
        if (cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.childCount != 0)
        {
            playerChange -= cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.GetChild(count).GetComponent<MoneyObj>().
                moneyValue;
            Destroy(cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.GetChild(count).gameObject);
            userChange.text = "Player Change: " + playerChange;
        }
    }

    public void EndTransaction()
    {
        NPCCheckpoints.GetComponent<NPCCheckPointManager>().npcExit = true;
        foreach(Transform transform in cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform)
        {
            Destroy(transform.gameObject);
        }
        cashierPanel.SetActive(false);
        mouseLook.GetComponent<MouseLook>().isInCashier = false;
    }
}
