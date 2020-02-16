using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimation : MonoBehaviour
{
    public Animator anim;

    private Throwables thr;
    private bool won;

    void Start()
    {
        thr = gameObject.GetComponent<Throwables>();
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (won)
        {
            return;
        }
        anim.SetFloat("Speed", thr.Speed);
        anim.SetBool("Flying", thr.Flying);
        anim.SetBool("Held", thr.Held);
        anim.SetBool("Landed", thr.Landed);
    }

    public void OnWon()
    {
        anim.SetBool("Won", true);
        won = true;
    }
}
