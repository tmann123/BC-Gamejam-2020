using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;

    private PlayerInputs input;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInputs>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        ProcessHorizontal();
    }

    private void ProcessHorizontal() {
        float x = input.Movement.x;
        float z = input.Movement.y;

        // Move with respect to players current rotation
        Vector3 move = transform.right * x + transform.forward * z;

        // DeltaTime will prevent framerate dependance
        controller.Move(move * speed * Time.deltaTime);
    }
}
