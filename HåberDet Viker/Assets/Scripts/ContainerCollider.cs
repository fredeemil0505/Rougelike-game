using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerCollider : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    [SerializeField] public GameObject coin;
    private bool isReady = false;

    private void Update()
    {
        if (isReady)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q Was Pressed Trigger");
                Instantiate(coin, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.enabled = true;
            isReady = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.enabled = false;
            isReady = false;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("I am active");
    //    if (collision.tag == "Player")
    //    {
    //        Debug.Log("This is the player");
    //        if (Input.GetKeyDown(KeyCode.Q))
    //        {
    //            Debug.Log("Space Was Pressed Trigger");
    //            Instantiate(coin, transform.position, Quaternion.identity);
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
