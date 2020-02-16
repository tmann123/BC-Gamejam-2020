using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAnimation : MonoBehaviour
{   
    public Animator anim;
    private InteractWithThrowable item;

    void Start() {
        item = GetComponent<InteractWithThrowable>();    
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!Input.anyKey){
            anim.SetBool("isIdle", true);
        } else {
            anim.SetBool("isIdle", false);
            anim.Play("MovingForward", -1);
        }
        if (Input.GetKeyUp("e") && item.holdingThrowable){
            anim.Play("Throw Object", -1);
        } 
    }
}
