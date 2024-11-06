using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    Vector3 velocity;
    public float gravity;
    public GameObject computer;
    public GameObject cashier;
    public float playerMoney;
    public Text playerMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        gravity = -9.8f;
        playerMoney = 500;
        DisplayPlayerMoney();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.enabled)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            characterController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }

    public void ToggleController()
    {
        characterController.enabled = !characterController.enabled;
    }

    public void ToggleCashierController()
    {
        cashier.GetComponent<CashierManager>().enabled =
            !cashier.GetComponent<CashierManager>().enabled;
    }

    public void ToggleComputerController()
    {
        computer.GetComponent<ComputerManager>().enabled =
            !computer.GetComponent<ComputerManager>().enabled;
    }

    public void DisplayPlayerMoney()
    {
        playerMoneyText.text = "Total Money: " + playerMoney + "P";
    }
}
