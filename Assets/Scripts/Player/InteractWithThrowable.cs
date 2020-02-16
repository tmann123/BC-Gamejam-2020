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
    
    public float rotationSpeed;



    // private
    private RaycastHit objectHit;
    public bool holdingThrowable;
    private Throwables heldItem;
    private PlayerInputs input;
    private Animator anim;


 
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInputs>();
        holdingThrowable = false;
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!holdingThrowable && DetectThrowable() && input.PickUp)
        {
            PickupObject();
        }
        if(holdingThrowable){
            ChangeThrowAngle();
            if (!input.PickUp)
            {
                ThrowObject();
            }
        }
    }

    //Checks if the ray is hitting an object, if the ray hits a throwable PickupObject will happen
    private bool DetectThrowable(){
        // Draws a ray and stores the if the ray has hit anything, if it does hit something then objectHit is updated
        bool didHit = Physics.Raycast(ray.transform.position, ray.transform.TransformDirection(new Vector3(0,-1,0.3f)), out objectHit, interactDistance);
        if (didHit && (objectHit.transform.GetComponent<Throwables>() != null))
        {
            return true;
        }
        didHit = Physics.Raycast(ray.transform.position, ray.transform.TransformDirection(new Vector3(0, -1, 0.6f)), out objectHit, interactDistance);
        if (didHit && (objectHit.transform.GetComponent<Throwables>() != null))
        {
            return true;
        }

        return false;
    }

    //TODO Sets holdingThrowable to true, just putting it here if we need it
    private void PickupObject(){
        //The throwable object
        heldItem = objectHit.transform.GetComponent<Throwables>();
        heldItem.GetComponent<Collider>().enabled = false;
        
        //I don't know if tbl.Pickup() is needed either but its there for now
        heldItem.Pickup();
        holdingThrowable = true;
    }

    private void ThrowObject()
    {
        //I don't know if tbl.Pickup() is needed either but its there for now
        holdingThrowable = false;
        heldItem.Throw(objectHit.transform.forward);
        connectPoint.transform.rotation = gameObject.transform.rotation;
        anim.Play("Throw Object", -1);
        heldItem.GetComponent<Collider>().enabled = true;
    }

    private void ChangeThrowAngle(){
        //rotatedAmount += new Vector3(-3,0,0)*Time.deltaTime*rotationSpeed;
        heldItem.transform.position = connectPoint.transform.position;
        heldItem.transform.rotation = connectPoint.transform.rotation;

        if(connectPoint.transform.rotation.eulerAngles.x > 290.0f || connectPoint.transform.rotation.eulerAngles.x == 0 )
        {
            connectPoint.transform.Rotate(new Vector3(-3,0,0) * Time.deltaTime * rotationSpeed);
        } else {
            connectPoint.transform.Rotate(Vector3.zero);
        }

         
    }
}
