using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCart : MonoBehaviour
{
    public CartManager cartmanager;
    public int item;

    public void AddCartItem()
    {
        if (cartmanager.i <2)
        {
            cartmanager.cart[cartmanager.i] = item;
            Debug.Log("Item Added: "+ cartmanager.cart[cartmanager.i] );
            cartmanager.i++;
        }
        else
        {
            Debug.Log("Cart Full");
            Debug.Log("Items: " + cartmanager.cart[0] + ", " + cartmanager.cart[1]);
        }
    }
}
