using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithThrowable : MonoBehaviour
{
    private Collider blah;

    private RaycastHit objectHit;

    public float interactDistance;

    public GameObject ray;

    private bool isholdingThrowable;


 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForObject();
    }

    //Checks if the ray is hitting an object, if the ray hits a throwable PickupObject will happen
    void CheckForObject(){
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

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
        Throwables tbl = objectHit.transform.GetComponent<Throwables>();
        if (Input.GetKeyDown("space")){
            //I don't know if tbl.Pickup() is needed either but its there for now
            tbl.Pickup();
            isholdingThrowable = true;
        }
    }

    

}
