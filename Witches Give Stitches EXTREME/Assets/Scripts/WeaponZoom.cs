using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInMouseSensitivity = .5f;
    [SerializeField] float zoomedOutMouseSensitivity = 2f;
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController; // needed the proper namespace to use this class

    bool zoomedInToggle = false;

    void OnDisable() 
    {
        if (zoomedInToggle == true)
        {
            ZoomOut();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
        
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomedInMouseSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInMouseSensitivity;
    }
    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutMouseSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutMouseSensitivity;
    }
}
