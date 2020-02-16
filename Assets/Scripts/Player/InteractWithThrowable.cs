using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithThrowable : MonoBehaviour
{
    private Collider blah;

    private RaycastHit objectHit;

    private bool isholdingThrowable;
    private Throwables heldItem;

    public float interactDistance;

    public GameObject ray;

    public GameObject connectPoint;

 
    // Start is called before the first frame update
    void Start()
    {
        ray = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForObject();
        if(isholdingThrowable){
            Debug.Log("throwable transform being changed");
            heldItem.transform.position = connectPoint.transform.position;
            heldItem.transform.rotation = connectPoint.transform.rotation;
            ThrowObject();
        }
    }

    //Checks if the ray is hitting an object, if the ray hits a throwable PickupObject will happen
    void CheckForObject(){


        // Draws a ray and stores the if the ray has hit anything, if it does hit something then objectHit is updated
        bool didHit = Physics.Raycast(ray.transform.position, ray.transform.TransformDirection(new Vector3(0,-1,1)), out objectHit, interactDistance);
        if (didHit)
        {
            Debug.DrawRay(ray.transform.position, ray.transform.TransformDirection(new Vector3(0,-1,1)) * objectHit.distance, Color.yellow);
            if (objectHit.transform.tag == "throwable"){
                Debug.Log("Did Hit");
                PickupObject();
                
            } else {
                Debug.Log("Did Not Hit");
                //TODO
            }

        }
        else
        {
            Debug.DrawRay(ray.transform.position, ray.transform.TransformDirection(new Vector3(0,-1,1)) * 1000, Color.white);
            Debug.Log("Did not Hit");
            //TODO
        }
    }

    //TODO Sets holdingThrowable to true, just putting it here if we need it
    void PickupObject(){
        //The throwable object
        heldItem = objectHit.transform.GetComponent<Throwables>();
        
        if (Input.GetKeyDown("space")){
            //I don't know if tbl.Pickup() is needed either but its there for now
            heldItem.Pickup();
            isholdingThrowable = true;
            Debug.Log("f key pressed");
        }
    }

    void ThrowObject(){

        if (Input.GetKeyDown("e")){
            //I don't know if tbl.Pickup() is needed either but its there for now
            isholdingThrowable = false;
            heldItem.Throw(objectHit.transform.forward);
            
        }

    }

    

}
