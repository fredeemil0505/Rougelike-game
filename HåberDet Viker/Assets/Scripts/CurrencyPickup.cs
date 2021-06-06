using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{
    public enum PickupObject {COIN,GEM}
    public PickupObject currentObject;
    public int pickupQuantity;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats.playerStats.AddCurrency(pickupQuantity, currentObject);
            Destroy(gameObject);
        }
    }
}
