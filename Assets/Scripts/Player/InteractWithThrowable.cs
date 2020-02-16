using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithThrowable : MonoBehaviour
{
    // public
    public float interactDistance;
    // Set in Prefab
    public GameObject ray;
    // Set in Prefab
    public GameObject connectPoint;

    // private
    private RaycastHit objectHit;
    private bool holdingThrowable;
    private Throwables heldItem;
    private PlayerInputs input;

 
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInputs>();
        holdingThrowable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!holdingThrowable && DetectThrowable() && input.PickUp)
        {
            PickupObject();
        }
        if(holdingThrowable){
            Debug.Log("throwable transform being changed");
            heldItem.transform.position = connectPoint.transform.position;
            heldItem.transform.rotation = connectPoint.transform.rotation;
            if (!input.PickUp)
            {
                ThrowObject();
            }
        }
    }

    //Checks if the ray is hitting an object, if the ray hits a throwable PickupObject will happen
    private bool DetectThrowable(){
        // Draws a ray and stores the if the ray has hit anything, if it does hit something then objectHit is updated
        bool didHit = Physics.Raycast(ray.transform.position, ray.transform.TransformDirection(new Vector3(0,-1,1)), out objectHit, interactDistance);
        return (objectHit.transform.GetComponent<Throwables>() != null);
    }

    //TODO Sets holdingThrowable to true, just putting it here if we need it
    private void PickupObject(){
        //The throwable object
        heldItem = objectHit.transform.GetComponent<Throwables>();
        
        //I don't know if tbl.Pickup() is needed either but its there for now
        heldItem.Pickup();
        holdingThrowable = true;
        Debug.Log("f key pressed");
    }

    private void ThrowObject()
    {
        //I don't know if tbl.Pickup() is needed either but its there for now
        holdingThrowable = false;
        heldItem.Throw(objectHit.transform.forward);
    }
}
