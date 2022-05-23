using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    // Ammo can see this and work with its public variables, but 
    // Something else like, say, Weapon, couldn't
    [System.Serializable]
    private class AmmoSlot 
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    // //return amt of ammo we have
    // public int GetCurrentAmmo() 
    // {
    //     return ammoAmount;
    // }

    // //reduce amt of ammo we have
    // public void ReduceCurrentAmmo()
    // {
    //     ammoAmount--;
    // }
}
