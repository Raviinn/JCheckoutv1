using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        detectDistance = 7f;
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

        if (Input.GetKeyDown(KeyCode.Space) && player.GetComponent<CharacterController>().enabled == false)
            //Enable Cashier UI when NPC is in Position
        {
            if (NPCCheckpoints.transform.Find("CheckPointCashier").transform.childCount != 0)
            {
                //Display UI
                if (cashierPanel.activeSelf == true)
                {
                    mouseLook.GetComponent<MouseLook>().isInCashier = false;
                    cashierPanel.SetActive(false);
                }
                //Close UI
                else
                {
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
        Instantiate(moneyPrefab[0], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position, Quaternion.identity);
        Debug.Log("1");
    }
    public void GiveChange20()
    {
        //put money into cash location
        Instantiate(moneyPrefab[1], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position, Quaternion.identity);
        Debug.Log("20");
    }

    public void GiveChange50()
    {
        //put money into cash location
        Instantiate(moneyPrefab[2], cashier.transform.Find("Cashier/Group1/Mesh1/MoneyHolder").transform.position, Quaternion.identity);
        Debug.Log("50");
    }
}
