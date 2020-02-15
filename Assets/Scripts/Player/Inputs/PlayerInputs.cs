using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Vector2 movement = Vector2.zero;
    private Vector2 mouseDrift = Vector2.zero;

    public Vector2 Movement { get { return movement; } }
    public Vector2 MouseDrift { get { return mouseDrift; } }

    // Called when movement keys are pressed
    void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    // Called when mouse is moved
    void OnLook(InputValue value) {
        mouseDrift = value.Get<Vector2>();
        Debug.Log("Movement is: " + mouseDrift);
    }
}
