using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 3f;

    private Vector3 velocity;
    private Transform groundCheck;
    private CharacterController controller;
    private PlayerInputs input;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");
        input = GetComponent<PlayerInputs>();

        if (groundCheck == null) {
            Debug.Log("Missing Ground Check, try fisxing object name");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessVertical();
    }

    private void ProcessVertical() {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && input.Jump) {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }
        else if (isGrounded && velocity.y < 0) {
            // -2f is low force that covers case of ground being registered before being on it completely
            velocity.y = -2f;
        }
        else {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

}
