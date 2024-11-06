using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickupLayerMask;
    private ComputerManager computerManager;
    private float detectDistance;
    public GameObject player;
    public GameObject computerCheckPoints;
    public GameObject mouseLook;
    public GameObject computerPanel;
    public Dropdown dropDown;
    private ObjectGrabbable[] setPriceObjects;
    public Text srpText;
    public InputField newPrice;
    // Start is called before the first frame update
    void Start()
    {
        detectDistance = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleComputer();
        
    }

    private void HandleComputer()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (player.GetComponent<CharacterController>().enabled == true)
            {
                if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                        out RaycastHit raycastHit, detectDistance, pickupLayerMask))
                {

                    if (raycastHit.transform.TryGetComponent(out computerManager))
                    {
                        try
                        {
                            player.GetComponent<PlayerManager>().ToggleController();
                        }
                        catch (System.Exception)
                        {

                        }
                        mouseLook.GetComponent<MouseLook>().isInPosition = true;
                        player.transform.position = computerCheckPoints.transform.position;
                        computerPanel.SetActive(true);
                        ResetComputerPanel();
                        Debug.Log("Computer");
                    }

                }
            }
            else 
            {
                player.GetComponent<PlayerManager>().ToggleController();
                mouseLook.GetComponent<MouseLook>().isInPosition = false;
                CloseAllPanels();
                computerPanel.SetActive(false);
                Debug.Log("Close");
            }
        }
    }

    private void ResetComputerPanel()
    {
        computerPanel.transform.GetChild(0).gameObject.SetActive(true);
        computerPanel.transform.GetChild(1).gameObject.SetActive(false);
        computerPanel.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void CloseAllPanels()
    {
        computerPanel.transform.GetChild(0).gameObject.SetActive(true);
        computerPanel.transform.GetChild(1).gameObject.SetActive(true);
        computerPanel.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void BuyStocks()
    {
        computerPanel.transform.GetChild(0).gameObject.SetActive(false);
        computerPanel.transform.GetChild(1).gameObject.SetActive(true);
        computerPanel.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void SetPrice()
    {
        computerPanel.transform.GetChild(0).gameObject.SetActive(false);
        computerPanel.transform.GetChild(1).gameObject.SetActive(false);
        computerPanel.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void LookForItems()
    {
        setPriceObjects = null;
        setPriceObjects = FindObjectsOfType<ObjectGrabbable>();

        if (dropDown.value == 1)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "BottledWater")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 2)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "CannedBeer")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 3)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Sandwich")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }

                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 4)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Milk")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 5)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Chips")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 6)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Coffee")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 7)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "EnergyDrink")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 8)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "SoftDrink")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 9)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "ChewingGum")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 10)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Cigarette")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 11)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Apple")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 12)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Cherry")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 13)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Orange")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
        else if (dropDown.value == 14)
        {
            if (setPriceObjects.Length != 0)
            {
                foreach (ObjectGrabbable obj in setPriceObjects)
                {
                    if (obj.objectName == "Guava")
                    {
                        srpText.text = obj.objectPrice + "P";
                        newPrice.text = obj.objectPrice.ToString();
                        break;
                    }
                    srpText.text = "0P";
                    newPrice.text = "0";
                }
            }
        }
    }

    public void Save()
    {
        setPriceObjects = null;
        setPriceObjects = FindObjectsOfType<ObjectGrabbable>();

        int result;
        if (int.TryParse(newPrice.text, out result))
        {
            if (dropDown.value == 1)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "BottledWater")
                        {
                            obj.objectPrice = int.Parse(newPrice.text); 
                        }
                    }
                }
            }else if (dropDown.value == 2)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "CannedBeer")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 3)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Sandwich")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 4)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Milk")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 5)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Chips")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 6)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Coffee")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 7)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "EnergyDrink")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 8)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "SoftDrink")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 9)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "ChewingGum")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 10)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Cigarette")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 11)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Apple")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 12)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Cherry")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 13)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Orange")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
            else if (dropDown.value == 14)
            {
                if (setPriceObjects.Length != 0)
                {
                    foreach (ObjectGrabbable obj in setPriceObjects)
                    {
                        if (obj.objectName == "Guava")
                        {
                            obj.objectPrice = int.Parse(newPrice.text);
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Input is not a valid number.");
        }

        ResetSetPricePanel();

    }

    public void ResetSetPricePanel()
    {
        dropDown.value = 0;
        srpText.text = null;
        newPrice.text = null;
    }

}
