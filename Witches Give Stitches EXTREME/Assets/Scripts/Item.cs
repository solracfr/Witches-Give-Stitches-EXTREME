using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    WinHandler winHandler;

    private void Start()
    {
        winHandler = FindObjectOfType<WinHandler>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            // make it so that these items add to an overall score
            Debug.Log("You hit an item!");
            Destroy(gameObject);

            // raise player's total
            winHandler.GetItem();
        }
    }
}
