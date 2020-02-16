using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "NPC")
        {
            collider.gameObject.GetComponent<NpcAnimation>().OnWon();
            collider.gameObject.GetComponent<NpcMovement>().OnWon();
            collider.gameObject.GetComponent<NpcAttributes>().OnWon();
        }
    }
}
