using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwables : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;

    private bool isPickedUp;

    public GameObject ray;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        throw new System.NotSupportedException();
    }

    void Throw(Vector3 direction) {

        isPickedUp = false;
    }

    public void Pickup(){
        isPickedUp = true;
    }

    
}
