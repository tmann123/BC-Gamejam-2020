using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private int totalNpc;
    private int currNpc;
    void Start()
    {
        totalNpc = GameObject.FindGameObjectsWithTag("NPC").Length;
        currNpc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currNpc == totalNpc)
        {
            // TODO
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "NPC")
        {
            currNpc++;
            collider.gameObject.GetComponent<NpcAnimation>().OnWon();
            collider.gameObject.GetComponent<NpcMovement>().OnWon();
            collider.gameObject.GetComponent<NpcAttributes>().OnWon();
        }
    }
}
