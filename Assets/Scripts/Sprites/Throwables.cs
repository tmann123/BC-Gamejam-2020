﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    // public
    public float throwspeed;

    // private
    private Rigidbody rb;
    private bool lockedMovement;
    private bool flying;
    public float speed;
    private bool held;
    private bool landed;

    // getters
    public float Speed { get { return speed; } }
    public bool Flying { get { return flying; } }
    public bool Held { get { return held; } }
    public bool Landed { get { return landed; } }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lockedMovement = false;
        flying = false;
        held = false;
        landed = true;
        flying = false;
    }

    // Update is called once per frame
    void Update() {
        speed = rb.velocity.magnitude;
        if (lockedMovement && !flying)
        {
            rb.useGravity = false;
        }
        if (speed < 0.3 && flying)
        {
            Land();
        }
    }

    public void Throw(Vector3 direction) {
        rb.AddForce(direction.normalized * throwspeed);
        rb.useGravity = true;
        held = false;
        flying = true;
    }

    public void Pickup(){
        gameObject.SendMessage("LockMovement");
        landed = false;
        held = true;
        lockedMovement = true;
    }

    private void Land()
    {
        gameObject.SendMessage("UnlockMovement");
        landed = true;
        lockedMovement = false;
        flying = false;
    }
    
}
