using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float maxCamClamp = 10f;
    [SerializeField] private float minCamClamp = 2f;

    private float xRotation;
    private PlayerInputs input;
    private Transform cameraTransfrom;
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Awake()
    {
        LockCursor();
        xRotation = 0.0f;
        playerBody = transform.parent;
        input = GetComponentInParent<PlayerInputs>();
        
        // Main Camera is a child of the camera pivot
        cameraTransfrom = transform.GetChild(0);
        cameraOffset = cameraTransfrom.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        CameraZoom();
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Rotate camera based on mouse delta since last frame
    private void CameraRotation() {
        // Get mouse drift from previous frame
        float mouseX = input.MouseDrift.x * Time.deltaTime;
        float mouseY = input.MouseDrift.y * Time.deltaTime;

        // Clamp rotation so that up/down can't look backwards
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        // Rotate body based on mouse drift
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Zoom towards/away from player based on mouse scroll
    private void CameraZoom() {
        cameraOffset.z += input.MouseScroll;
        // Camera behind player, swap clamp bounds to negative values
        cameraOffset.z = Mathf.Clamp(cameraOffset.z, -maxCamClamp, -minCamClamp);

        cameraTransfrom.localPosition = cameraOffset;
    }
}
