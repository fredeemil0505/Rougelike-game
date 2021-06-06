using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOverlayController : MonoBehaviour
{
    [SerializeField] public GameObject Inventory;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                Inventory.SetActive(false);
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                Inventory.SetActive(true);
                isPaused = true;
            }
            
        }
    }
}
