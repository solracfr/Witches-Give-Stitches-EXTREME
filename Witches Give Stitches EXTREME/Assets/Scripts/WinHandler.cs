using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] int numItemsGathered = 0; 
    [SerializeField] int totalItemsLeft = 5;

    // Update is called once per frame
    public void GetItem()
    {
        numItemsGathered++;

        if (numItemsGathered >= totalItemsLeft)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
