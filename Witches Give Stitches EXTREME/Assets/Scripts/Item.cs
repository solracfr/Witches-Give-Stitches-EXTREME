using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    WinHandler winHandler;

    [SerializeField] int ammoAmt = 5;

    [SerializeField] AmmoType ammoType;

    private void Start()
    {
        winHandler = FindObjectOfType<WinHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            if (gameObject.CompareTag("Key Item"))
            {
                // raise player's total
                winHandler.GetItem();
            }
            else
            {
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmt);
            }
            Destroy(gameObject);
        }
    }
}
