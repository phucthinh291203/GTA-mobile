using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement playerMovement;
    CameraManager cameraManager;
    Animator anim;

    public bool isInteracting;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        cameraManager = FindObjectOfType<CameraManager>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        cameraManager.HandleAllCameraMovement();
    }

    private void FixedUpdate()
    {
        playerMovement.HandleAllMovement();
    }

    private void LateUpdate()
    {
        isInteracting = anim.GetBool("isInteracting");
        playerMovement.isJumping = anim.GetBool("isJumping");
        anim.SetBool("isGrounded", playerMovement.isGrounded);
    }
}
