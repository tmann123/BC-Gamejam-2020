using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    // public
    public float npcRelRadius;
    public float npcBorderRadius;
    public float npcTimer;
    public bool free;

    // private
    private NavMeshAgent agent;
    private float timer;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = npcTimer;
        // TODO we need to change startpos when the npc gets yeet'ed to the landing spot
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if NPC is free to move
        if (!free)
        {
            // Buffer timer for the NPC to move as soon as free'd
            timer = npcTimer;
            return;
        }
        // If the NPC has recently been flung outside the borderRadius, reset startPos
        if (!PositionInsideRadius(transform.position, startPos))
        {
            startPos = transform.position;
            timer = npcTimer;
        }
        // Check if time to find new position to move to
        timer += Time.deltaTime;
        if (timer >= npcTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, npcRelRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    /* 
     * RandomNavSphere
     * Requires:    currPos - current position of the NPC
     *              relRadius - relative radius border the NPC is allowed to be in
     *              layermask - ignored as value -1
     * Returns:     New position on the NavMeshMap for the NPC to move to
     */
    private Vector3 RandomNavSphere(Vector3 currPos, float relRadius, int layermask)
    {
        NavMeshHit navHit;
        Vector3 randDirection = Random.insideUnitSphere * relRadius;

        // Find a position in randDirection inside the NavMesh
        randDirection += currPos;
        NavMesh.SamplePosition(randDirection, out navHit, relRadius, layermask);
        if (PositionInsideRadius(navHit.position, startPos))
        {
            // Position is inside borderRadius and relRadius, move to it
            return navHit.position;
        }
        else
        {
            // Buffer timer to run RandomNavSphere again
            timer = npcTimer;
            return currPos;
        }
    }

    /* 
    * PositionInsideRadius
    * Requires:    currPos - current position of the NPC
    *              origin - absolute radius border the NPC is allowed to be in
    * Returns:     TRUE if currPos is in the radius circle of origin, FALSE otherwise
    */
    private bool PositionInsideRadius(Vector3 currPos, Vector3 origin)
    {
        return (npcBorderRadius > Mathf.Sqrt(Mathf.Pow((currPos.x - origin.x), 2) + Mathf.Pow((currPos.y - origin.y), 2)));
    }
}
