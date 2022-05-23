using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false; // turn off canvas
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0; // stops the game entirely
        FindObjectOfType<WeaponSwitcher>().enabled = false; // turn off our weapons for the day 
        Cursor.lockState = CursorLockMode.None; // free cursor as though you were pressing esc
        Cursor.visible = true; // make cursor visible 
    }
}
