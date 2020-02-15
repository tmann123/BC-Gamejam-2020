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
    void Update() {
        throw new System.NotSupportedException();
    }

    void Throw(Vector3 direction) {
        throw new System.NotSupportedException();
    }

    void Accelerate() {
        throw new System.NotSupportedException();
    }

    void Pickup() {
        throw new System.NotSupportedException();
    }

    public void EnableInteract() {
        throw new System.NotSupportedException();
    }


}
