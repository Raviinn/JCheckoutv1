using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartManager : MonoBehaviour
{
    public int[] cart = new int[2];
    public int i = 0;

    public Text Item1;
    public Text Item2;

    private void Update()
    {
        switch (cart[0])
        {
            case 1:
                Item1.text = "Bottled Water";
                break;
            case 2:
                Item1.text = "Canned Beer";
                break;
            case 3:
                Item1.text = "Sandwich";
                break;
            case 4:
                Item1.text = "Milk";
                break;
            case 5:
                Item1.text = "Coffee";
                break;
            case 6:
                Item1.text = "Energy Drink";
                break;
            case 7:
                Item1.text = "Soft Drink";
                break;
            case 8:
                Item1.text = "Chewing Gum";
                break;
            case 9:
                Item1.text = "Cigarette";
                break;
        }

        switch (cart[1])
        {
            case 1:
                Item2.text = "Bottled Water";
                break;
            case 2:
                Item2.text = "Canned Beer";
                break;
            case 3:
                Item2.text = "Sandwich";
                break;
            case 4:
                Item2.text = "Milk";
                break;
            case 5:
                Item2.text = "Coffee";
                break;
            case 6:
                Item2.text = "Energy Drink";
                break;
            case 7:
                Item2.text = "Soft Drink";
                break;
            case 8:
                Item2.text = "Chewing Gum";
                break;
            case 9:
                Item2.text = "Cigarette";
                break;
        }
    }
}
