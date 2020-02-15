using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTesting : MonoBehaviour
{
    private Collider body;
    public float speed;
    // Start is clled before the first frame update
    void Start()
    {
        body = GetComponent<CapsuleCollider>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")){
            body.transform.position += Time.deltaTime * speed * new Vector3(-1,0,0);

        }if (Input.GetKey("s")){
            body.transform.position += Time.deltaTime * speed * new Vector3(1,0,0);

        }if (Input.GetKey("a")){
            body.transform.position += Time.deltaTime * speed * new Vector3(0,0,-1);

        }if (Input.GetKey("d")){
            body.transform.position += Time.deltaTime * speed * new Vector3(0,0,1);

        }
    }
}
