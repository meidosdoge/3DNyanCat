using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesativaMovPlayer : MonoBehaviour
{
    public static DesativaMovPlayer desMov;

    public GameObject player, mainCam;
    private CharacterController playerController;
    private PlayerLook look;
    private DogRaycast dogRay;
    private PlayerMovement move;

    void OnEnable()
    {
        desMov = this;

        look = mainCam.GetComponent<PlayerLook>();
        dogRay = mainCam.GetComponent<DogRaycast>();
        move = player.GetComponent<PlayerMovement>();
        playerController = player.GetComponent<CharacterController>();

        Cursor.visible = false;
    }

    public void AtivaMov()
    {
        look.enabled = true;
        dogRay.enabled = true;
        move.enabled = true;
        playerController.enabled = true;
    }

    public void DesativaMov()
    {
        look.enabled = false;
        dogRay.enabled = false;
        move.enabled = false;
        playerController.enabled = false;
    }

    public void AtivaCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DesativaCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}