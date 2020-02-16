using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;
    private Vector3 velocity;
    private Transform groundCheck;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");

        if (groundCheck == null) {
            Debug.Log("Missing Ground Check, try fisxing object name");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            // -2f is low force that covers case of ground being registered before being on it completely
            velocity.y = -2f;
        }
        else {
            velocity.y += gravity * Time.deltaTime * Time.deltaTime;
            controller.Move(velocity);
        }
    }
}
