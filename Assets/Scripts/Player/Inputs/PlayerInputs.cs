using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private float scrollTick = 0.1f;
    [SerializeField] private float mouseSensitivity = 10f;

    private Vector2 movement = Vector2.zero;
    private Vector2 mouseDrift = Vector2.zero;
    private bool pickUp = false;
    private float mouseScroll = 0f;
    private bool jump = false;

    public Vector2 Movement { get { return movement; } }
    public Vector2 MouseDrift { get { return mouseDrift; } }
    public float MouseScroll { get { return mouseScroll; } }
    public bool PickUp { get { return pickUp; } }
    public bool Jump { get { return jump; } }

    private void LateUpdate() {
        jump = false;
    }

    // Called when movement keys are pressed
    void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    // Called when mouse is moved
    void OnLook(InputValue value) {
        mouseDrift = value.Get<Vector2>() * mouseSensitivity;
    }

    void OnZoom(InputValue value) {
        var rawScroll = value.Get<Vector2>().y;

        // Normalize a tick to the scroll tick value
        mouseScroll = Mathf.Clamp(rawScroll, -scrollTick, scrollTick);
    }

    void OnJump() {
        jump = true;
    }

    // Called when item is picked up/dropped
    void OnPickUp()
    {
        pickUp = !pickUp;
    }
}
