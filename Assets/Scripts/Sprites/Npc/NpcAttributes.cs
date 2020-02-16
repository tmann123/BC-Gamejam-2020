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
    public float intoPoolCompassion = 5f;
    public float deadCompassion = -5f;
    public float hurtCompassion = -2f;

    // private
    private float health;
    private Throwables thr;
    private bool damageTaken;
    private bool won;
    private PlayerCompassion playerCompRef;

    // Start is called before the first frame update
    void Start()
    {
        health = initHealth;
        thr = gameObject.GetComponent<Throwables>();
        damageTaken = false;
        won = false;
        playerCompRef = GameObject.FindGameObjectWithTag("Giant").GetComponent<PlayerCompassion>();
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

            if (health <= 0f) {
                playerCompRef.ChangeCompassion(deadCompassion);
            }
            else {
                playerCompRef.ChangeCompassion(hurtCompassion);
            }
        }
    }

    public void OnWon()
    {
        won = true;
    }
}
