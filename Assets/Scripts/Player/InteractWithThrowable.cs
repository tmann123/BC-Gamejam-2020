using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithThrowable : MonoBehaviour
{
    public GameObject giant;
    private Throwables tbl;
    private Collider Blah;
    private bool zowie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision){
        Throwables temp = collision.collider.GetComponent<Throwables>();

        if (temp != null){
            temp.EnableInteract();
        }
    }

}
