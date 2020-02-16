using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    // public
    public float throwspeed;

    // private
    private Rigidbody rb;
    private bool lockedMovement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lockedMovement = false;
    }

    // Update is called once per frame
    void Update() {
        if(lockedMovement)
        {
            Debug.Log("Gravity turned off");
            rb.useGravity = false;
            //The giant will need change the transform of the Throwable
        }
    }

    public void Throw(Vector3 direction) {
        rb.AddForce(direction.normalized * throwspeed);
        rb.useGravity = true;
        // TODO need to reimplement this so the npc doesn't move in midair
        lockedMovement = false;
    }

    public void Pickup(){
        Debug.Log("Picked up");
        gameObject.SendMessage("LockedMovement");
        lockedMovement = true;
    }

    
}
