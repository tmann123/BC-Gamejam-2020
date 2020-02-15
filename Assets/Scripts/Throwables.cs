using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    private Rigidbody rb;
    private Collider[] area;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        area = rb.GetComponentsInChildren<Collider>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Throw(Vector3 direction)
    {

    }

    void Accelerate()
    {
        
    }

    void Pickup(){

    }

    public void enableInteract(){

    }


}
