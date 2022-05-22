using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    //return amt of ammo we have
    public int GetCurrentAmmo() 
    {
        return ammoAmount;
    }

    //reduce amt of ammo we have
    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }
}
