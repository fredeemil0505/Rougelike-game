using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Item item;
    [SerializeField] Inventory inventory;
    private SpriteRenderer image;

    private void Start()
    {
        image = gameObject.GetComponent<SpriteRenderer>();
        image.sprite = item.Icon;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
