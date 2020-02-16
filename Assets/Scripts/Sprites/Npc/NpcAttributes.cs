using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAttributes : MonoBehaviour
{
    // public
    public float compassion;
    public float initHealth;
    public float damageSpeed;
    public float damagePerCollide;

    // private
    private float health;
    private Throwables thr;
    private bool damageTaken;
    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        thr = gameObject.GetComponent<Throwables>();
        damageTaken = false;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!thr.Flying)
        {
            damageTaken = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (thr.Speed >= damageSpeed && !damageTaken)
        {
            damageTaken = true;
            health -= damagePerCollide;
        }
        if (collision.collider.tag == "Pool" && thr.Flying && !won)
        {
            // TODO
            won = true;
        }
    }
}
