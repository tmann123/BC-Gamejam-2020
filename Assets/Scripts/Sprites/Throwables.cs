using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    private Rigidbody rb;
    public float throwspeed;

    private bool isPickedUp;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        if(isPickedUp){
            Debug.Log("Gravity turned off");
            rb.useGravity = false;
            //The giant will need change the transform of the Throwable
        }
    }

    public void Throw(Vector3 direction) {
        
        rb.AddForce(direction.normalized * throwspeed);

        rb.useGravity = true;
        isPickedUp = false;
    }

    public void Pickup(){
        Debug.Log("Picked up");
        isPickedUp = true;
    }

    
}
