using System;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    public event Action PlayerEnteredShop; //an event is simply a way to notify other parts of the game when something happens without connecting them directly.
    public event Action PlayerExitedShop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEnteredShop?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExitedShop?.Invoke();
        }
    }
}