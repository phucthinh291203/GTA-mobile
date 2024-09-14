using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform playerTranform;
    public Transform cameraPivot;
    private Vector3 camFollowVelocity = Vector3.zero;

    [Header("Camera movement and rotation")]
    public float camFollowSpeed = 0.1f;
    public float camLookSpeed = 0.1f;
    public float camPivotSpeed = 0.1f;
    public float lookAngle;
    public float pivotAngle;

    public float minimumPivotAngle = -30f;
    public float maximumPivotAngle = 30f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputManager = FindObjectOfType<InputManager>();
        playerTranform = FindAnyObjectByType<PlayerManager>().transform;
    }


    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }
    void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, playerTranform.position, ref camFollowVelocity, camFollowSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        //Tính horizontal và vertical
        lookAngle += (inputManager.cameraInputX * camLookSpeed);
        pivotAngle -= (inputManager.cameraInputY * camPivotSpeed);

        //Giới hạn góc quay của camera
        pivotAngle = Mathf.Clamp(pivotAngle,minimumPivotAngle,maximumPivotAngle);

        //Hortizontal
        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        //Vertical
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }
}
