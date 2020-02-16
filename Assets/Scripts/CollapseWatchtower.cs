using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseWatchtower : MonoBehaviour
{
    public GameObject tower;
    public GameObject invisibleWall;
    
    private float timer;

    void Start() {
        timer = 0.0f;
        tower.GetComponent<Rigidbody>().detectCollisions = false;
    }
    void OnTriggerEnter(Collider other) {
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 5.0f){
            Debug.Log("transforming");
            tower.transform.Translate(new Vector3(0,20,0));
            tower.transform.Rotate(new Vector3(90,0,0));

            Debug.Log("Enabling Wall");
            tower.GetComponent<Rigidbody>().detectCollisions = false;
            invisibleWall.SetActive(true);

        }
    }
}
