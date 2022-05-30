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

    //return amt of ammo we have
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    //increase amt of ammo we have, depending on the item we pickup
    public int IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        return GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    //reduce amt of ammo we have
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
